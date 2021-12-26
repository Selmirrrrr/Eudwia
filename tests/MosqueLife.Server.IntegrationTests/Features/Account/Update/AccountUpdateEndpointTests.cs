using System.Net.Http.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MosqueLife.Server.Data;
using MosqueLife.Server.IntegrationTests.Fixtures;
using MosqueLife.Shared.Features.Account.Details;
using MosqueLife.Shared.Features.Account.Update;
using Shouldly;
using Xunit;

namespace MosqueLife.Server.IntegrationTests.Features.Account.Update;

[Collection(DatabaseTestsCollection.CollectionName)]
public class AccountUpdateEndpointTests 
{
    private readonly DatabaseFixture _databaseFixture;

    public AccountUpdateEndpointTests(DatabaseFixture  databaseFixture)
    {
        _databaseFixture = databaseFixture;
    }

    [Fact]
    public async Task UpdateAccountDetails()
    {
        // Arrange
        var client = await _databaseFixture.CreateAuthorizedClient();

        using var userManager = _databaseFixture.Services.CreateScope().ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var userId = (await userManager.FindByEmailAsync(DatabaseFixture.TestEmail)).Id;
        
        // Act
        var updateResult = await client.PostAsJsonAsync($"api/account/{userId}", new AccountUpdateCommand
        {
            Firstname = "updated.firstname",
            Lastname = "updated.lastname"
        });

        var result = await client.GetFromJsonAsync<AccountDetailsViewModel>($"api/account/{userId}");

        // Assert
        result.ShouldNotBeNull();
        result.Firstname.ShouldBe("updated.firstname");
        result.Lastname.ShouldBe("updated.lastname");
        updateResult.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
    }
}
