#nullable disable
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Eudwia.Server.Data.Contexts.Extensions;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace Eudwia.Server.Data.Contexts;

public class ApplicationDbContext : IdentityDbContext<Member, IdentityRole<Guid>, Guid>
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly IContextConfiguration _config;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ILoggerFactory loggerFactory, IContextConfiguration config)
        : base(options)
    {
        _loggerFactory = loggerFactory;
        _config = config;
    }

    public virtual DbSet<Member> Members { get; set; }
    public virtual DbSet<Country> Countries { get; set; }
    public virtual DbSet<Payment> Payments { get; set; }
    public virtual DbSet<SubscriptionPaid> SubscriptionsPaid { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        modelBuilder.Seed();

        modelBuilder.Entity<SubscriptionPaid>().HasKey(o => new { o.MemberId, o.Year });
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
}
