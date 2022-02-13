#nullable disable
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Eudwia.Server.Data.Contexts.Extensions;
using Eudwia.Server.Data.Contracts;
using Eudwia.Server.Providers;
using Eudwia.Server.Settings;
using Microsoft.Extensions.Options;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

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

        modelBuilder.Entity<SubscriptionPaid>().HasKey(o => new {o.MemberId, o.Year});
        modelBuilder.Entity<Member>().HasQueryFilter(b => EF.Property<Guid>(b, "TenantId") == _currentUserProvider.TenantId);
        modelBuilder.Entity<Payment>().HasQueryFilter(b => EF.Property<Guid>(b, "TenantId") == _currentUserProvider.TenantId);
        modelBuilder.Entity<SubscriptionPaid>().HasQueryFilter(b => EF.Property<Guid>(b, "TenantId") == _currentUserProvider.TenantId);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;

        optionsBuilder
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging()
            .UseNpgsql(_config.ConnectionString, SqlServerOptionsAction)
            .UseLoggerFactory(_loggerFactory);
    }

    private void SqlServerOptionsAction(NpgsqlDbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.GetName().Name);
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var addedTenantEntries = ChangeTracker.Entries<ITenantEntity>().Where(x => x.State == EntityState.Added);
        var addedEntries = ChangeTracker.Entries<IAuditableEntity>().Where(x => x.State == EntityState.Added);
        var modifiedEntries = ChangeTracker.Entries<IAuditableEntity>().Where(x => x.State == EntityState.Modified);

        foreach (var entry in addedTenantEntries.Where(x => x.Entity.TenantId == Guid.Empty)) entry.Entity.TenantId = _currentUserProvider.TenantId;

        foreach (var entry in addedEntries)
        {
            entry.CurrentValues[nameof(IAuditableEntity.AuditCreatedAt)] = DateTime.UtcNow;
            entry.CurrentValues[nameof(IAuditableEntity.AuditCreatedBy)] = _currentUserProvider.Username;
        }

        foreach (var entry in modifiedEntries)
        {
            entry.CurrentValues[nameof(IAuditableEntity.AuditModifiedAt)] = DateTime.UtcNow;
            entry.CurrentValues[nameof(IAuditableEntity.AuditModifiedBy)] = _currentUserProvider.Username;
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}