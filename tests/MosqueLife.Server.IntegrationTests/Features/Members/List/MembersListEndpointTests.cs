using System.Net.Http.Json;
using MosqueLife.Server.IntegrationTests.Fixtures;
using MosqueLife.Shared.Features.Members.List;
using Shouldly;
using Xunit;

namespace MosqueLife.Server.IntegrationTests.Features.Members.List;

[Collection(DatabaseTestsCollection.CollectionName)]
public class MembersListEndpointTests 
{
    private readonly DatabaseFixture _databaseFixture;

    public MembersListEndpointTests(DatabaseFixture databaseFixture)
    {
        _databaseFixture = databaseFixture;
    }

    [Fact]
    public async Task GetOneSimpleMember()
    {
        // Arrange
        var client = await _databaseFixture.CreateAuthorizedClient();

        // Act
        var result = await client.GetFromJsonAsync<MembersListViewModel[]>("api/members");

        // Assert
        result.ShouldNotBeNull();
        result.Length.ShouldBeGreaterThan(20);
    }
}
