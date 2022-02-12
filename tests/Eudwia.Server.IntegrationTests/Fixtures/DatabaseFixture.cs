using System.Net.Http.Headers;
using System.Net.Http.Json;
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
using Eudwia.Server.Data;
using Eudwia.Server.Data.Contexts;
using Eudwia.Shared.Features.Authentication.Login;
using Xunit;

namespace Eudwia.Server.IntegrationTests.Fixtures
{
    public class DatabaseFixture : WebApplicationFactory<Startup>, IAsyncLifetime
    {
        public const string TestEmail = "test@example.com";
        public const string TestPassword = "Pass$w0rd";
        private PostgreSqlTestcontainer ContainerFixture { get; }

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
            builder.ConfigureTestServices((Action<IServiceCollection>)(async services =>
            {
                services.BuildServiceProvider();
                services.Replace(new ServiceDescriptor(typeof(IContextConfiguration), new TestContextConfiguration(ContainerFixture.ConnectionString)));

                var sp = services.BuildServiceProvider();

                using var scope = sp.CreateScope();
                var scopedServices = scope.ServiceProvider;
                var context = scopedServices.GetRequiredService<ApplicationDbContext>();

                context.Database.Migrate();

                var userManager = scopedServices.GetRequiredService<UserManager<Member>>();

                var newUser = new Member 
                { 
                    UserName = TestEmail, 
                    Email = TestEmail, 
                    FirstName = "Test", 
                    LastName = "Example"
                };

                await userManager.CreateAsync(newUser, TestPassword);
            }));
        }

        public async Task<HttpClient> CreateAuthorizedClient()
        {
            var client = CreateClient();
            var resultLogin = await client.PostAsJsonAsync("api/account/login", new LoginCommand
            {
                Email = TestEmail,
                Password = TestPassword
            });

            var content = await resultLogin.Content.ReadFromJsonAsync<LoginResult>();
            var token = content?.Token;

            client.DefaultRequestHeaders.Authorization = string.IsNullOrWhiteSpace(token)
                ? null
                : new AuthenticationHeaderValue("bearer", token);

            return client;
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
