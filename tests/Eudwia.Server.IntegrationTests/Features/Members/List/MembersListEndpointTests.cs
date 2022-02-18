using System.Net.Http.Json;
using Microsoft.Extensions.DependencyInjection;
using Eudwia.Server.Data.Contexts;
using Eudwia.Server.Data.Contexts.Extensions;
using Eudwia.Server.IntegrationTests.Fixtures;
using Eudwia.Shared.Features.Members.List;
using Shouldly;
using Xunit;
using System.Net;

namespace Eudwia.Server.IntegrationTests.Features.Members.List;

[Collection(DatabaseTestsCollection.CollectionName)]
public class MembersListEndpointTests
{
    private readonly DatabaseFixture _databaseFixture;

    public MembersListEndpointTests(DatabaseFixture databaseFixture)
    {
        _databaseFixture = databaseFixture;
    }

    [Fact]
    public async Task GetMembersReturnsMembresWhenUserIsAdmin()
    {
        // Arrange
        var client = await _databaseFixture.CreateAdminClient();
        await using var context = _databaseFixture.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var baseMember = context.Members.Add(DatabaseFixture.CreateNewMember(_databaseFixture.TenantId)).Entity;
        await context.SaveChangesAsync();

        // Act
        var result = await client.GetFromJsonAsync<MembersListViewModel[]>("api/members");

        // Assert
        result.ShouldNotBeNull();
        result.Any(m => m.Id == baseMember.Id).ShouldBeTrue();
    }

    [Fact]
    public async Task GetMembersReturns403WhenUserIsNotAdmin()
    {
        // Arrange
        var client = await _databaseFixture.CreateUserClient();

        // Act
        var result = await client.GetAsync("api/members");

        // Assert
        result.StatusCode.ShouldBe(HttpStatusCode.Forbidden);
    }
}