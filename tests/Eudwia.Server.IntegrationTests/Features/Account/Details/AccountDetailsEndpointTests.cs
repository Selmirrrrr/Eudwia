using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Eudwia.Server.Data;
using Eudwia.Server.IntegrationTests.Fixtures;
using Eudwia.Shared.Features.Account.Details;
using Eudwia.Shared.Features.Authentication.Register;
using Shouldly;
using Xunit;
using Eudwia.Server.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Eudwia.Server.IntegrationTests.Features.Account.Details;

[Collection(DatabaseTestsCollection.CollectionName)]
public class AccountDetailsEndpointTests
{
    private readonly DatabaseFixture _databaseFixture;

    public AccountDetailsEndpointTests(DatabaseFixture databaseFixture)
    {
        _databaseFixture = databaseFixture;
    }

    [Fact]
    public async Task MembersDetailsReturn404WhenUnauthorized()
    {
        // Arrange
        var client = _databaseFixture.CreateClient();

        // Act
        async Task Act()
        {
            await client.GetFromJsonAsync<AccountDetailsViewModel>($"api/account/{Guid.Empty}");
        }

        // Assert
        var ex = await Should.ThrowAsync<HttpRequestException>(Act);
        ex.StatusCode.ShouldBe(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task MembersDetailsReturn401WhenMembersDontExists()
    {
        // Arrange
        var client = await _databaseFixture.CreateUserClient();

        // Act
        async Task Act()
        {
            await client.GetFromJsonAsync<AccountDetailsViewModel>($"api/account/{Guid.Empty}");
        }

        // Assert
        var ex = await Should.ThrowAsync<HttpRequestException>(Act);
        ex.StatusCode.ShouldBe(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task MembersDetailsReturnMember()
    {
        // Arrange
        var client = await _databaseFixture.CreateUserClient();
        using var context = _databaseFixture.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var user = await context.Members.FirstAsync(m => m.Email == "user@example.com");

        // Act
        var memberResult = await client.GetFromJsonAsync<AccountDetailsViewModel>($"api/account/{user.Id}");

        // Assert
        memberResult.ShouldNotBeNull();
        memberResult.Id.ShouldBe(user.Id);
    }
}