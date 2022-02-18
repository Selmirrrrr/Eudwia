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
using Eudwia.Shared.Authorization;
using Eudwia.Shared.Features.Authentication.Login;
using Xunit;

namespace Eudwia.Server.IntegrationTests.Fixtures;

public class DatabaseFixture : WebApplicationFactory<Startup>, IAsyncLifetime
{
    private readonly (string Email, string Password) _user = ("user@example.com", "Pass$w0rd");
    private readonly (string Email, string Password) _admin = ("admin@example.com", "Pass$w0rd");
    private readonly (string Email, string Password) _superAdmin = ("superadmin@example.com", "Pass$w0rd");

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
        //ContainerFixture.StartAsync().Wait();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.BuildServiceProvider();
            services.Replace(new ServiceDescriptor(typeof(IContextConfiguration), new TestContextConfiguration(ContainerFixture.ConnectionString)));

            var sp = services.BuildServiceProvider();

            using var scope = sp.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var context = scopedServices.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();

            var userManager = scopedServices.GetRequiredService<UserManager<Member>>();
            var roleManager = scopedServices.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            var superAdminRole = roleManager.CreateAsync(new IdentityRole<Guid>(Roles.SuperAdmin)).GetAwaiter().GetResult();
            var adminRole = roleManager.CreateAsync(new IdentityRole<Guid>(Roles.Admin)).GetAwaiter().GetResult();
            var userRole = roleManager.CreateAsync(new IdentityRole<Guid>(Roles.User)).GetAwaiter().GetResult();

            var user = new Member
            {
                UserName = _user.Email,
                Email = _user.Email,
                FirstName = "user",
                LastName = "user"
            };

            var r = userManager.CreateAsync(user, _user.Password).GetAwaiter().GetResult();
            var rr = userManager.AddToRoleAsync(user, Roles.User).GetAwaiter().GetResult();

            var admin = new Member
            {
                UserName = _admin.Email,
                Email = _admin.Email,
                FirstName = "admin",
                LastName = "admin"
            };

            var rrr = userManager.CreateAsync(admin, _admin.Password).GetAwaiter().GetResult();
            var rrrr = userManager.AddToRoleAsync(admin, Roles.Admin).GetAwaiter().GetResult();

            var superAdmin = new Member
            {
                UserName = _superAdmin.Email,
                Email = _superAdmin.Email,
                FirstName = "superadmin",
                LastName = "superadmin"
            };

            var rrrrr = userManager.CreateAsync(superAdmin, _superAdmin.Password).GetAwaiter().GetResult();
            var rrrrrr = userManager.AddToRoleAsync(superAdmin, Roles.SuperAdmin).GetAwaiter().GetResult();
        });
    }

    private async Task<HttpClient> CreatAuthClient(string email, string password)
    {
        
        var client = CreateClient();
        var resultLogin = await client.PostAsJsonAsync("api/account/login", new LoginCommand
        {
            Email = email,
            Password = password
        });

        var content = await resultLogin.Content.ReadFromJsonAsync<LoginResult>();
        var token = content?.Token;

        client.DefaultRequestHeaders.Authorization = string.IsNullOrWhiteSpace(token)
            ? null
            : new AuthenticationHeaderValue("bearer", token);

        return client;
    }

    public async Task<HttpClient> CreateUserClient() => await CreatAuthClient(_user.Email, _user.Password);
    public async Task<HttpClient> CreateAdminClient() => await CreatAuthClient(_admin.Email, _admin.Password);
    public async Task<HttpClient> CreateSuperAdminClient() => await CreatAuthClient(_superAdmin.Email, _superAdmin.Password);

    public async Task InitializeAsync()
    {
        ContainerFixture.StartAsync().Wait();
        CreateClient();
    }

    async Task IAsyncLifetime.DisposeAsync() => await ContainerFixture.DisposeAsync();
}