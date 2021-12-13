#nullable disable
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MosqueLife.Server.Data.Contexts.Extensions;
using Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace MosqueLife.Server.Data.Contexts;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    private readonly IConfiguration _configuration;
    private readonly ILoggerFactory _loggerFactory;
    private readonly IContextConfiguration _config;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ILoggerFactory loggerFactory, IConfiguration configuration, IContextConfiguration config)
        : base(options)
    {
        (_loggerFactory, _configuration) = (loggerFactory, configuration);
        _config = config;
    }

    public virtual DbSet<Member> Members { get; set; }
    public virtual DbSet<State> States { get; set; }
    public virtual DbSet<Country> Countries { get; set; }
    public virtual DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        modelBuilder.Seed();

        modelBuilder.Entity<SubscriptionPaid>().HasKey(o => new { o.MemberId, o.Year, o.Month });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;

        optionsBuilder
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging()
            .UseNpgsql(
                connectionString: _config.ConnectionString,
                npgsqlOptionsAction: SqlServerOptionsAction)
            .UseLoggerFactory(_loggerFactory);
    }

    private void SqlServerOptionsAction(NpgsqlDbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.MigrationsAssembly(assemblyName: typeof(ApplicationDbContext).Assembly.GetName().Name);
}
