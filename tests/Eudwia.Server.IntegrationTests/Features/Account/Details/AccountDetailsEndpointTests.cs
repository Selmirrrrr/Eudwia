﻿using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Eudwia.Server.Data;
using Eudwia.Server.IntegrationTests.Fixtures;
using Eudwia.Shared.Features.Account.Details;
using Eudwia.Shared.Features.Authentication.Register;
using Shouldly;
using Xunit;

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
    public async Task MembersDetailsRetunr404WhenUnauthorized()
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
    public async Task MembersDetailsRetunr401WhenMembersDontExists()
    {
        // Arrange
        var client = await _databaseFixture.CreateAuthorizedClient();

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
        var client = await _databaseFixture.CreateAuthorizedClient();
        const string email = "mirsel.doe@exemple.ch";
        const string password = "Passw0rd!";
        
        await client.PostAsJsonAsync("api/account/register", new RegisterModel
        {
            Email = email,
            Password = password,
            ConfirmPassword = password,
            FirstName = "sdfs",
            LastName = "sdfsd"
        });

        using var userManager = _databaseFixture.Services.CreateScope().ServiceProvider.GetRequiredService<UserManager<Member>>();
        var userId = (await userManager.FindByEmailAsync(email)).Id;
        
        // Act
        var memberResult = await client.GetFromJsonAsync<AccountDetailsViewModel>($"api/account/{userId}");
        
        // Assert
        memberResult.ShouldNotBeNull();
        memberResult.Id.ShouldBe(userId);
    }
}