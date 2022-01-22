using System.Net.Http.Json;
using Microsoft.Extensions.DependencyInjection;
using MosqueLife.Server.Data.Contexts;
using MosqueLife.Server.Data.Contexts.Extensions;
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
        await using var context = _databaseFixture.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var baseMember = context.Members.Add(ModelBuilderExtensions.CreateMember()).Entity;
        await context.SaveChangesAsync();

        // Act
        var result = await client.GetFromJsonAsync<MembersListViewModel[]>("api/members");

        // Assert
        result.ShouldNotBeNull();
        result.Any(m => m.Id == baseMember.Id).ShouldBeTrue();
    }
}
