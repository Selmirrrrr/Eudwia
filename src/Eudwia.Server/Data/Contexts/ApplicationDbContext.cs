#nullable disable
using Eudwia.Server.Data.AutoHistory.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Eudwia.Server.Data.Contexts.Extensions;
using Eudwia.Server.Data.Contracts;
using Eudwia.Server.Providers;
using Eudwia.Server.Settings;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Options;

namespace Eudwia.Server.Data.Contexts;

public class ApplicationDbContext : IdentityDbContext<Member, IdentityRole<Guid>, Guid>
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly IContextConfiguration _config;
    private readonly ICurrentUserProvider _currentUserProvider;
    private readonly SuperAdminAccountSettings _adminAccountSettings;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
        ILoggerFactory loggerFactory,
        IContextConfiguration config,
        IOptions<SuperAdminAccountSettings> adminAccountSettings,
        ICurrentUserProvider currentUserProvider)
        : base(options)
    {
        _loggerFactory = loggerFactory;
        _config = config;
        _currentUserProvider = currentUserProvider;
        _adminAccountSettings = adminAccountSettings.Value;
    }

    public virtual DbSet<Member> Members { get; set; }
    public virtual DbSet<Country> Countries { get; set; }
    public virtual DbSet<Payment> Payments { get; set; }
    public virtual DbSet<SubscriptionPaid> SubscriptionsPaid { get; set; }
    public virtual DbSet<Tenant> Tenants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        modelBuilder.Seed();
        
        if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));
                var dateTimeProperties = entityType.ClrType.GetProperties()
                    .Where(p => p.PropertyType == typeof(DateTimeOffset));

                foreach (var property in properties)
                {
                    modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion<double>();
                }

                foreach (var property in dateTimeProperties)
                {
                    modelBuilder.Entity(entityType.Name).Property(property.Name)
                        .HasConversion(new DateTimeOffsetToBinaryConverter());
                }
            }
        }

        // enable auto history functionality.
        modelBuilder.EnableAutoHistory();
        
        modelBuilder.Entity<Member>().HasQueryFilter(p => !p.IsDeleted);
        modelBuilder.Entity<Member>().HasQueryFilter(b => EF.Property<Guid>(b, "TenantId") == _currentUserProvider.TenantId);
        
        modelBuilder.Entity<Payment>().HasQueryFilter(p => !p.IsDeleted);
        modelBuilder.Entity<Payment>().HasQueryFilter(b => EF.Property<Guid>(b, "TenantId") == _currentUserProvider.TenantId);
        
        modelBuilder.Entity<SubscriptionPaid>().HasKey(o => new {o.MemberId, o.Year});
        modelBuilder.Entity<SubscriptionPaid>().HasQueryFilter(p => !p.IsDeleted);
        modelBuilder.Entity<SubscriptionPaid>().HasQueryFilter(b => EF.Property<Guid>(b, "TenantId") == _currentUserProvider.TenantId);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;

        optionsBuilder
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging()
            .UseSqlite(_config.ConnectionString, SqlServerOptionsAction)
            .UseLoggerFactory(_loggerFactory);
    }
    
    private static void SqlServerOptionsAction(SqliteDbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.GetName().Name);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        EnsureSoftDelete();
        EnsureAuditable();
        EnsureTenant();

        return await EnsureAutoHistory(cancellationToken);
    }

    private void EnsureAuditable()
    {
        var addedEntries = ChangeTracker.Entries<IAuditableEntity>().Where(x => x.State == EntityState.Added);
        var modifiedEntries = ChangeTracker.Entries<IAuditableEntity>().Where(x => x.State == EntityState.Modified);

        foreach (var entry in addedEntries)
        {
            entry.CurrentValues[nameof(IAuditableEntity.AuditCreatedAt)] = DateTime.UtcNow;
            entry.CurrentValues[nameof(IAuditableEntity.AuditCreatedBy)] = _currentUserProvider.FullName;
        }

        foreach (var entry in modifiedEntries)
        {
            entry.CurrentValues[nameof(IAuditableEntity.AuditModifiedAt)] = DateTime.UtcNow;
            entry.CurrentValues[nameof(IAuditableEntity.AuditModifiedBy)] = _currentUserProvider.FullName;
        }
    }

    private void EnsureTenant()
    {
        var addedTenantEntries = ChangeTracker.Entries<ITenantEntity>().Where(x => x.State == EntityState.Added);

        foreach (var entry in addedTenantEntries.Where(x => x.Entity.TenantId == Guid.Empty))
            entry.Entity.TenantId = _currentUserProvider.TenantId;
    }
    
    private void EnsureSoftDelete()
    {
        var deletedEntries = ChangeTracker.Entries<IAuditableEntity>().Where(x => x.State == EntityState.Deleted);

        foreach (var entry in deletedEntries)
        {
            entry.Entity.IsDeleted = true;
            entry.State = EntityState.Modified;
        }
    }

    private async Task<int> EnsureAutoHistory(CancellationToken cancellationToken)
    {
        var addedEntries = ChangeTracker.Entries<IAuditableEntity>().Where(x => x.State == EntityState.Added);

        this.EnsureAutoHistory();
        
        var result = await base.SaveChangesAsync(cancellationToken);

        this.EnsureAddedHistory(addedEntries.ToArray());

        await base.SaveChangesAsync(cancellationToken);

        return result;
    }
}