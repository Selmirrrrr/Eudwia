﻿using MosqueLife.Server.IntegrationTests.Fixtures;
using MosqueLife.Shared.Features.Members;
using MosqueLife.Shared.Models.Authentication;
using Shouldly;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Xunit;

namespace MosqueLife.Server.IntegrationTests.Features.Members;

[Collection(DatabaseTestsCollection.CollectionName)]
public class GetMembersTests 
{
    private readonly DatabaseFixture _databaseFixture;

    public GetMembersTests(DatabaseFixture databaseFixture)
    {
        _databaseFixture = databaseFixture;
    }

    [Fact]
    public async Task GetOneSimpleMember()
    {
        // Arrange
        var client = _databaseFixture.CreateClient();

        var resultLogin = await client.PostAsJsonAsync("api/account/login", new LoginCommand
        {
            Email = "test@example.com",
            Password = "Pass$w0rd",
        });

        var content = await resultLogin.Content.ReadFromJsonAsync<LoginResult>();
        var token = content?.Token;

        client.DefaultRequestHeaders.Authorization = string.IsNullOrWhiteSpace(token)
            ? null
            : new AuthenticationHeaderValue("bearer", token);

        // Act
        var result = await client.GetFromJsonAsync<GetMembersResult[]>("api/members");

        // Assert
        result.ShouldNotBeNull();
        result.Length.ShouldBe(20);
    }
}