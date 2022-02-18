using Eudwia.Server.Data.Contexts;
using Eudwia.Server.Features.Admin;
using Eudwia.Server.IntegrationTests.Fixtures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Net;
using Xunit;

namespace Eudwia.Server.IntegrationTests.Features.Admin.ImportMembers;

[Collection(DatabaseTestsCollection.CollectionName)]
public class ImportMembersEndpointTests
{
    private readonly DatabaseFixture _databaseFixture;
    private const string Route = "api/admin/import/";

    public ImportMembersEndpointTests(DatabaseFixture databaseFixture)
    {
        _databaseFixture = databaseFixture;
    }

    [Fact]
    public async Task Returns403WhenIsUser()
    {
        // Arrange
        var client = await _databaseFixture.CreateUserClient();
        var content = new MultipartFormDataContent();

        // Act
        var result = await client.PostAsync(Route, content);

        // Assert
        result.StatusCode.ShouldBe(HttpStatusCode.Forbidden);
    }

    [Fact]
    public async Task Returns403WhenIsAdmin()
    {
        // Arrange
        var client = await _databaseFixture.CreateAdminClient();
        var content = new MultipartFormDataContent();

        // Act
        var result = await client.PostAsync(Route, content);

        // Assert
        result.StatusCode.ShouldBe(HttpStatusCode.Forbidden);
    }



    [Fact]
    public async Task ReturnsOkWhenIsSuperAdminAndFileIsValid()
    {
        // Arrange
        var content = new MultipartFormDataContent
        {
            { new ByteArrayContent(File.ReadAllBytes("Features/Admin/ImportMembers/members.xlsx")), "file", "filename" }
        };

        var client = await _databaseFixture.CreateSuperAdminClient();

        // Act
        var reponse = await client.PostAsync(Route, content);

        // Assert
        reponse.StatusCode.ShouldBe(HttpStatusCode.OK);
        using var context = _databaseFixture.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var result = await context.Members.AnyAsync(m => m.Email == "ReturnsOkWhenIsSuperAdminAndFileIsValid@example.ch");
        result.ShouldBeTrue();
    }

    [Fact]
    public async Task ReturnsBadRequestWhenIsSuperAdminAndFileIsNotValid()
    {
        // Arrange
        var content = new MultipartFormDataContent();
        var client = await _databaseFixture.CreateSuperAdminClient();

        // Act
        var reponse = await client.PostAsync(Route, content);

        // Assert
        reponse.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
    }
}