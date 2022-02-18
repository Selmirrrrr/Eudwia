using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.DependencyInjection;
using Eudwia.Server.Data.Contexts;
using Eudwia.Server.Data.Contexts.Extensions;
using Eudwia.Server.IntegrationTests.Fixtures;
using Eudwia.Shared.Features.Members.Details;
using Shouldly;
using Xunit;

namespace Eudwia.Server.IntegrationTests.Features.Members.Details;

[Collection(DatabaseTestsCollection.CollectionName)]
public class MembersDetailsEndpointTests
{
    private readonly DatabaseFixture _databaseFixture;

    public MembersDetailsEndpointTests(DatabaseFixture databaseFixture)
    {
        _databaseFixture = databaseFixture;
    }

    [Fact]
    public async Task GetOneSimpleMember401WhenNotAuthenticated()
    {
        // Arrange
        var client = _databaseFixture.CreateClient();

        // Act
        async Task Act()
        {
            await client.GetFromJsonAsync<MembersDetailsViewModel>($"api/members/{Guid.Empty}");
        }

        // Assert
        var ex = await Should.ThrowAsync<HttpRequestException>(Act);
        ex.StatusCode.ShouldBe(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task GetOneSimpleMember404WhenNotIdDoesntExists()
    {
        // Arrange
        var client = await _databaseFixture.CreateAdminClient();

        // Act
        async Task Act()
        {
            await client.GetFromJsonAsync<MembersDetailsViewModel>($"api/members/{Guid.Empty}");
        }

        // Assert
        var ex = await Should.ThrowAsync<HttpRequestException>(Act);
        ex.StatusCode.ShouldBe(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetOneSimpleMemberReturnsMemberWhenIdExists()
    {
        // Arrange
        var client = await _databaseFixture.CreateAdminClient();
        await using var context = _databaseFixture.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var baseMember = context.Members.Add(DatabaseFixture.CreateNewMember(_databaseFixture.TenantId)).Entity;
        await context.SaveChangesAsync();

        // Act
        var result = await client.GetFromJsonAsync<MembersDetailsViewModel>($"api/members/{baseMember.Id}");

        // Assert
        result.ShouldNotBeNull();
        result.Id.ShouldBe(baseMember.Id);
    }

    [Fact]
    public async Task GetOneSimpleMember403WhenUserIsNotAuthorized()
    {
        // Arrange
        var client = await _databaseFixture.CreateUserClient();
        await using var context = _databaseFixture.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var member = context.Members.First();
        await context.SaveChangesAsync();

        // Act
        async Task Act()
        {
            await client.GetFromJsonAsync<MembersDetailsViewModel>($"api/members/{member.Id}");
        }

        // Assert
        var ex = await Should.ThrowAsync<HttpRequestException>(Act);
        ex.StatusCode.ShouldBe(HttpStatusCode.Forbidden);
    }
}