using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MosqueLife.Server.Data.Contexts;

namespace MosqueLife.Server.IntegrationTests;

public class WebApplicationFactoryWithInMemorySqlite : WebApplicationFactory<Startup>
{
    private readonly string _connectionString = "DataSource=:memory:";
    private readonly SqliteConnection _connection;

    public WebApplicationFactoryWithInMemorySqlite()
    {
        _connection = new SqliteConnection(_connectionString);
        _connection.Open();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder) =>
        builder.ConfigureServices(services =>
        {
            var context = services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(ApplicationDbContext));
            if (context != null)
            {
                services.Remove(context);
                var options = services.Where(r => (r.ServiceType == typeof(DbContextOptions))
                  || (r.ServiceType.IsGenericType && r.ServiceType.GetGenericTypeDefinition() == typeof(DbContextOptions<>))).ToArray();
                foreach (var option in options)
                {
                    services.Remove(option);
                }
            }

            services
                .AddEntityFrameworkSqlite()
                .AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlite(_connection);
                    options.UseInternalServiceProvider(services.BuildServiceProvider());
                });

            var sp = services.BuildServiceProvider();

            using var scope = sp.CreateScope();

            var scopedServices = scope.ServiceProvider;

            // try to receive context with inmemory provider:
            var db = scopedServices.GetRequiredService<ApplicationDbContext>();

            // Ensure the database is created.
            db.Database.EnsureCreated();
        });

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        _connection.Close();
    }
}

