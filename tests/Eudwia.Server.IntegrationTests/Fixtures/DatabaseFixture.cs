using System.Net.Http.Headers;
using System.Net.Http.Json;
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
using Bogus;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Eudwia.Shared.Enums;

namespace Eudwia.Server.IntegrationTests.Fixtures;

public class DatabaseFixture : WebApplicationFactory<Startup>, IAsyncLifetime
{
    private readonly (string Email, string Password) _user = ("user@example.com", "Pass$w0rd");
    private readonly (string Email, string Password) _admin = ("admin@example.com", "Pass$w0rd");
    private readonly (string Email, string Password) _superAdmin = ("superadmin@example.com", "Pass$w0rd");
    public readonly Guid TenantId = Guid.Parse("CABB6053-353B-44F9-8088-47BB609753E2");

    private PostgreSqlTestcontainer ContainerFixture { get; }

    public DatabaseFixture()
    {
        var testcontainersBuilder = new TestcontainersBuilder<PostgreSqlTestcontainer>()
            .WithDatabase(new MsSqlTestcontainerConfiguration()
            {
                Password = "Sup3r.Str0ng.P4ss"
            });

        ContainerFixture = testcontainersBuilder.Build();
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

            roleManager.CreateAsync(new IdentityRole<Guid>(Roles.SuperAdmin)).GetAwaiter().GetResult();
            roleManager.CreateAsync(new IdentityRole<Guid>(Roles.Admin)).GetAwaiter().GetResult();
            roleManager.CreateAsync(new IdentityRole<Guid>(Roles.User)).GetAwaiter().GetResult();

            var user = new Member
            {
                UserName = _user.Email,
                Email = _user.Email,
                FirstName = "user",
                LastName = "user"
            };

            userManager.CreateAsync(user, _user.Password).GetAwaiter().GetResult();
            userManager.AddToRoleAsync(user, Roles.User).GetAwaiter().GetResult();

            var admin = new Member
            {
                UserName = _admin.Email,
                Email = _admin.Email,
                FirstName = "admin",
                LastName = "admin",
                TenantId = TenantId
            };

            userManager.CreateAsync(admin, _admin.Password).GetAwaiter().GetResult();
            userManager.AddToRoleAsync(admin, Roles.Admin).GetAwaiter().GetResult();

            var superAdmin = new Member
            {
                UserName = _superAdmin.Email,
                Email = _superAdmin.Email,
                FirstName = "superadmin",
                LastName = "superadmin"
            };

            userManager.CreateAsync(superAdmin, _superAdmin.Password).GetAwaiter().GetResult();
            userManager.AddToRoleAsync(superAdmin, Roles.SuperAdmin).GetAwaiter().GetResult();
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

    public static Member CreateNewMember(Guid tenantGuid)
    {
        var faker = new Faker("fr");

        var guid = Guid.NewGuid();
        return new Member
        {
            Id = guid,
            FirstName = faker.Name.FirstName(),
            LastName = faker.Name.LastName(),
            Email = faker.Person.Email,
            PhoneNumber = faker.Person.Phone,
            BirthDate = faker.Date.Past(50, new DateTime(2000, 1, 1)),
            MemberSince = faker.Date.Past(10),
            StreetLine1 = faker.Address.StreetAddress(),
            StreetLine2 = faker.Address.SecondaryAddress(),
            HouseNumber = faker.Address.BuildingNumber(),
            City = faker.Address.City(),
            ZipCode = faker.Address.ZipCode(),
            State = "VD",
            CountryId = Guid.Parse("9bc1f1a9-7696-42e4-89aa-c93800704582"),
            Language = faker.Random.Enum<Language>(),
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = faker.Person.Email,
            TenantId = tenantGuid
        };
    }

    public async Task InitializeAsync()
    {
        await ContainerFixture.StartAsync();
        CreateClient();
    }

    async Task IAsyncLifetime.DisposeAsync() => await ContainerFixture.DisposeAsync();
}