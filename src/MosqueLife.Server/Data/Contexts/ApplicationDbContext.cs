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

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ILoggerFactory loggerFactory, IConfiguration configuration)
        : base(options) => (_loggerFactory, _configuration) = (loggerFactory, configuration);

    public virtual DbSet<Member> Members { get; set; }
    public virtual DbSet<State> States { get; set; }
    public virtual DbSet<Country> Countries { get; set; }

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

        var connectionStringBuilder = new NpgsqlConnectionStringBuilder(_configuration.GetConnectionString("PostgreSQL"))
        {
            Password = _configuration["DbPassword"]
        };

        connectionStringBuilder.Host = string.IsNullOrWhiteSpace(_configuration["DbHost"])
            ? connectionStringBuilder.Host
            : _configuration["DbHost"];

        optionsBuilder
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging()
            .UseNpgsql(
                connectionString: connectionStringBuilder.ConnectionString,
                npgsqlOptionsAction: SqlServerOptionsAction)
            .UseLoggerFactory(_loggerFactory);
    }

    private void SqlServerOptionsAction(NpgsqlDbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.MigrationsAssembly(assemblyName: typeof(ApplicationDbContext).Assembly.GetName().Name);
}
