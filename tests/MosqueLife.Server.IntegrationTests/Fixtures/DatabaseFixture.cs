using DotNet.Testcontainers.Containers.Builders;
using DotNet.Testcontainers.Containers.Configurations.Databases;
using DotNet.Testcontainers.Containers.Modules.Databases;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MosqueLife.Server.Data;
using MosqueLife.Server.Data.Contexts;
using Xunit;

namespace MosqueLife.Server.IntegrationTests.Fixtures
{
    public class DatabaseFixture : WebApplicationFactory<Startup>, IAsyncLifetime
    {
        public PostgreSqlTestcontainer ContainerFixture { get; }

        public DatabaseFixture()
        {
            var testcontainersBuilder = new TestcontainersBuilder<PostgreSqlTestcontainer>()
                .WithDatabase(new PostgreSqlTestcontainerConfiguration("postgres:bullseye")
                {
                    Database = "db",
                    Username = "postgres",
                    Password = "postgres"
                });

            ContainerFixture = testcontainersBuilder.Build();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(async services =>
            {
                services.BuildServiceProvider();
                services.Replace(new ServiceDescriptor(typeof(IContextConfiguration), new TestContextConfiguration(ContainerFixture.ConnectionString)));

                var sp = services.BuildServiceProvider();

                using var scope = sp.CreateScope();
                var scopedServices = scope.ServiceProvider;
                var context = scopedServices.GetRequiredService<ApplicationDbContext>();

                context.Database.Migrate();

                var userManager = scopedServices.GetRequiredService<UserManager<ApplicationUser>>();

                var newUser = new ApplicationUser { UserName = "test@example.com", Email = "test@example.com", Firstname = "Test", Lastname = "Example" };

                await userManager.CreateAsync(newUser, "Pass$w0rd");
            });
        }

        public async Task InitializeAsync()
        {
            await ContainerFixture.StartAsync();
        }

        async Task IAsyncLifetime.DisposeAsync()
        {
            await ContainerFixture.DisposeAsync();
        }
    }
}
