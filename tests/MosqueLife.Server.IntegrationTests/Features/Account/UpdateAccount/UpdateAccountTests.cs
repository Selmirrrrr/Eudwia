using MosqueLife.Server.IntegrationTests.Fixtures;
using Shouldly;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using MosqueLife.Shared.Features.Account.GetAccountDetails;
using MosqueLife.Shared.Features.Account.Login;
using MosqueLife.Shared.Features.Account.Register;
using MosqueLife.Shared.Features.Account.UpdateAccount;
using Xunit;

namespace MosqueLife.Server.IntegrationTests.Features.Account.UpdateAccount;

[Collection(DatabaseTestsCollection.CollectionName)]
public class UpdateAccountTests 
{
    private readonly DatabaseFixture _databaseFixture;

    public UpdateAccountTests(DatabaseFixture  databaseFixture)
    {
        _databaseFixture = databaseFixture;
    }

    [Fact]
    public async Task UpdateAccountDetails()
    {
        // Arrange
        var client = _databaseFixture.CreateClient();
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

        var updateResult = await client.PostAsJsonAsync($"api/account/{email}", new AccountUpdateCommand
        {
            Firstname = "updated.firstname",
            Lastname = "updated.lastname"
        });

        var result = await client.GetFromJsonAsync<AccountDetailsViewModel>($"api/account/{email}");

        // Assert
        result.ShouldNotBeNull();
        result.Firstname.ShouldBe("updated.firstname");
        result.Lastname.ShouldBe("updated.lastname");
        updateResult.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
    }
}
