using System.Net.Http.Json;
using System.Net.Http.Headers;
using MosqueLife.Shared.Models.Authentication;
using MosqueLife.Shared.Models.Personal;
using Shouldly;
using Xunit;

namespace MosqueLife.Server.IntegrationTests;

public class AccountControllerTests : IClassFixture<WebApplicationFactoryWithInMemorySqlite>
{
    private readonly WebApplicationFactoryWithInMemorySqlite _factory;

    public AccountControllerTests(WebApplicationFactoryWithInMemorySqlite factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task LoginFailWithInvalidEmailAsync()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var result = await client.PostAsJsonAsync("api/account/login", new LoginCommand { Email = "pauljean.ch", Password = "sdfsdsdfs", RememberMe = true });

        // Assert
        result.StatusCode.ShouldBe(System.Net.HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task RegisterSuccesful()
    {
        // Arrange
        var client = _factory.CreateClient();
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
        var client = _factory.CreateClient();
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

    [Fact]
    public async Task UpdateAccountDetails()
    {
        // Arrange
        var client = _factory.CreateClient();
        var email = "mirsel.doe@exemple.com";
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

        var resultLogin = await client.PostAsJsonAsync("api/account/login", new LoginCommand
        {
            Email = email,
            Password = password,
            RememberMe = true
        });

        var content = await resultLogin.Content.ReadFromJsonAsync<LoginResult>();
        var token = content?.Token;

        client.DefaultRequestHeaders.Authorization = string.IsNullOrWhiteSpace(token)
            ? null
            : new AuthenticationHeaderValue("bearer", token);

        var result = await client.PostAsJsonAsync($"api/account/{email}", new UpdateAccountCommand
        {
            Firstname = "updated.firstname",
            Lastname = "updated.lastname"
        });

        var getResult = await client.GetFromJsonAsync<GetAccountDetailsResult>($"api/account/{email}");

        // Assert
        getResult.ShouldNotBeNull();
        getResult.Firstname.ShouldBe("updated.firstname");
        getResult.Lastname.ShouldBe("updated.lastname");
        result.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetUnauthprizedFails()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        Func<Task> act = async () =>
        {
            await client.GetFromJsonAsync<GetAccountDetailsResult>($"api/account/notexists@email.com");
        };

        // Assert
        await Should.ThrowAsync<HttpRequestException>(() => act());
    }
}