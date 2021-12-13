using MosqueLife.Server.IntegrationTests.Fixtures;
using MosqueLife.Shared.Models.Authentication;
using Shouldly;
using System.Net.Http.Json;
using Xunit;

namespace MosqueLife.Server.IntegrationTests.Features.Account.Register;

[Collection(DatabaseTestsCollection.CollectionName)]
public class RegisterTests 
{
    private readonly DatabaseFixture _databaseFixture;

    public RegisterTests(DatabaseFixture  databaseFixture)
    {
        _databaseFixture = databaseFixture;
    }

    [Fact]
    public async Task RegisterSuccesful()
    {
        // Arrange
        var client = _databaseFixture.CreateClient();
        var password = "Passw0rd!";
        // Act
        var result = await client.PostAsJsonAsync("api/account/register", new RegisterModel { Email = "dfsdf@lol.ch", Password = password, ConfirmPassword = password, Firstname = "sdfs", Lastname = "sdfsd" });

        // Assert
        result.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
    }

    [Fact]
    public async Task RegisterLoginOk()
    {
        // Arrange
        var client = _databaseFixture.CreateClient();
        var email = "john.doe@exemple.com";
        var password = "Passw0rd!";

        // Act
        await client.PostAsJsonAsync("api/account/register", new RegisterModel
        {
            Email = email,
            Password = password,
            ConfirmPassword = password,
            Firstname = "sdfs",
            Lastname = "sdfsd"
        });

        var result = await client.PostAsJsonAsync("api/account/login", new LoginCommand
        {
            Email = email,
            Password = password,
            RememberMe = true
        });

        // Assert
        result.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
    }
}
