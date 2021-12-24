using MosqueLife.Server.IntegrationTests.Fixtures;
using Shouldly;
using System.Net.Http.Json;
using MosqueLife.Shared.Features.Account.GetAccountDetails;
using Xunit;

namespace MosqueLife.Server.IntegrationTests.Features.Account.GetAccountDetailsEndpoint;

[Collection(DatabaseTestsCollection.CollectionName)]
public class AccountDetailsEndpointTests
{
    private readonly DatabaseFixture _databaseFixture;

    public AccountDetailsEndpointTests(DatabaseFixture databaseFixture)
    {
        _databaseFixture = databaseFixture;
    }

    [Fact]
    public async Task GetOneSimpleMember()
    {
        // Arrange
        var client = _databaseFixture.CreateClient();

        // Act
        async Task Act()
        {
            await client.GetFromJsonAsync<AccountDetailsViewModel>("api/account/notexists@email.com");
        }

        // Assert
        await Should.ThrowAsync<HttpRequestException>(Act);
    }
}
