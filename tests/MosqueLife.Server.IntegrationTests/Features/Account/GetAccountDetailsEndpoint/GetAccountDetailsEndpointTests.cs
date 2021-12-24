using MosqueLife.Server.IntegrationTests.Fixtures;
using Shouldly;
using System.Net.Http.Json;
using MosqueLife.Shared.Features.Account.GetAccountDetails;
using Xunit;

namespace MosqueLife.Server.IntegrationTests.Features.Account.GetAccountDetailsEndpoint;

[Collection(DatabaseTestsCollection.CollectionName)]
public class GetAccountDetailsEndpointTests
{
    private readonly DatabaseFixture _databaseFixture;

    public GetAccountDetailsEndpointTests(DatabaseFixture databaseFixture)
    {
        _databaseFixture = databaseFixture;
    }

    [Fact]
    public async Task GetOneSimpleMember()
    {
        // Arrange
        var client = _databaseFixture.CreateClient();

        // Act
        Func<Task> act = async () =>
        {
            await client.GetFromJsonAsync<GetAccountDetailsResult>($"api/account/notexists@email.com");
        };

        // Assert
        await Should.ThrowAsync<HttpRequestException>(() => act());
    }
}
