using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.Extensions.DependencyInjection;
using MosqueLife.Server.Data.Contexts;
using MosqueLife.Server.Data.Contexts.Extensions;
using MosqueLife.Server.IntegrationTests.Fixtures;
using MosqueLife.Shared.Features.Authentication.Login;
using MosqueLife.Shared.Features.Members.Details;
using MosqueLife.Shared.Features.Members.List;
using Shouldly;
using Xunit;

namespace MosqueLife.Server.IntegrationTests.Features.Members.Details;

[Collection(DatabaseTestsCollection.CollectionName)]
public class MembersDetailsEndpointTests 
{
    private readonly DatabaseFixture _databaseFixture;

    public MembersDetailsEndpointTests(DatabaseFixture databaseFixture)
    {
        _databaseFixture = databaseFixture;
    }

    [Fact]
    public async Task GetOneSimpleMember401WhenNotAuthorized()
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
        var client = await _databaseFixture.CreateAuthorizedClient();
        
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
        var client = await _databaseFixture.CreateAuthorizedClient();
        await using var context = _databaseFixture.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var member = context.Members.Add(ModelBuilderExtensions.CreateMember()).Entity;
        await context.SaveChangesAsync();
        
        // Act
        var result = await client.GetFromJsonAsync<MembersDetailsViewModel>($"api/members/{member.Id}");
        
        // Assert
        result.ShouldNotBeNull();
        result.Id.ShouldBe(member.Id);
    }
}
