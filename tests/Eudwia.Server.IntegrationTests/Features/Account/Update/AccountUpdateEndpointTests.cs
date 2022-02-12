using System.Net.Http.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Eudwia.Server.Data;
using Eudwia.Server.IntegrationTests.Fixtures;
using Eudwia.Shared.Features.Account.Details;
using Eudwia.Shared.Features.Account.Update;
using Shouldly;
using Xunit;

namespace Eudwia.Server.IntegrationTests.Features.Account.Update;

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

        using var userManager = _databaseFixture.Services.CreateScope().ServiceProvider.GetRequiredService<UserManager<Member>>();
        var userId = (await userManager.FindByEmailAsync(DatabaseFixture.TestEmail)).Id;
        
        // Act
        var updateResult = await client.PostAsJsonAsync($"api/account/{userId}", new AccountUpdateCommand
        {
            FirstName = "updated.firstname",
            LastName = "updated.lastname"
        });

        var result = await client.GetFromJsonAsync<AccountDetailsViewModel>($"api/account/{userId}");

        // Assert
        result.ShouldNotBeNull();
        result.FirstName.ShouldBe("updated.firstname");
        result.LastName.ShouldBe("updated.lastname");
        updateResult.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
    }
}
