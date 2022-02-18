using System.Net.Http.Json;
using Eudwia.Server.IntegrationTests.Fixtures;
using Eudwia.Shared.Features.Authentication.Login;
using Eudwia.Shared.Features.Authentication.Register;
using Shouldly;
using Xunit;

namespace Eudwia.Server.IntegrationTests.Features.Account.Register;

[Collection(DatabaseTestsCollection.CollectionName)]
public class RegisterEndpointTests
{
    private readonly DatabaseFixture _databaseFixture;

    public RegisterEndpointTests(DatabaseFixture databaseFixture)
    {
        _databaseFixture = databaseFixture;
    }

    [Fact]
    public async Task RegisterSuccesful()
    {
        // Arrange
        var client = _databaseFixture.CreateClient();
        const string password = "Passw0rd!";

        // Act
        var result = await client.PostAsJsonAsync("api/account/register", new RegisterModel 
        {
            Email = "dfsdf@lol.ch", 
            Password = password, 
            ConfirmPassword = password, 
            FirstName = "sdfs", 
            LastName = "sdfsd",
            Tenant = Guid.NewGuid().ToString()
        });

        // Assert
        result.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
    }

    [Fact]
    public async Task RegisterLoginOk()
    {
        // Arrange
        var client = _databaseFixture.CreateClient();
        const string email = "john.doe@exemple.com";
        const string password = "Passw0rd!";

        // Act
        await client.PostAsJsonAsync("api/account/register", new RegisterModel
        {
            Email = email,
            Password = password,
            ConfirmPassword = password,
            FirstName = "sdfs",
            LastName = "sdfsd",
            Tenant = Guid.NewGuid().ToString()
        });

        var result = await client.PostAsJsonAsync("api/account/login", new LoginCommand
        {
            Email = email,
            Password = password
        });

        // Assert
        result.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
    }

    [Fact]
    public async Task RegisterLoginFailsWhenTenantExists()
    {
        // Arrange
        var tenantId = Guid.NewGuid().ToString();
        var client = _databaseFixture.CreateClient();
        await client.PostAsJsonAsync("api/account/register", new RegisterModel
        {
            Email = "email@example.com",
            Password = "Pas$wo0rd",
            ConfirmPassword = "Pas$wo0rd",
            FirstName = "sdfs",
            LastName = "sdfsd",
            Tenant = tenantId
        });

        // Act
        var result = await client.PostAsJsonAsync("api/account/register", new RegisterModel
        {
            Email = "email2@example.com",
            Password = "Pas$wo0rd",
            ConfirmPassword = "Pas$wo0rd",
            FirstName = "sdfs",
            LastName = "sdfsd",
            Tenant = tenantId
        });


        // Assert
        result.StatusCode.ShouldBe(System.Net.HttpStatusCode.BadRequest);
    }
}