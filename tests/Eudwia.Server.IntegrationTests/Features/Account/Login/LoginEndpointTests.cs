using System.Net.Http.Json;
using Eudwia.Server.IntegrationTests.Fixtures;
using Eudwia.Shared.Features.Authentication.Login;
using Shouldly;
using Xunit;

namespace Eudwia.Server.IntegrationTests.Features.Account.Login;

[Collection(DatabaseTestsCollection.CollectionName)]
public class LoginEndpointTests
{
    private readonly DatabaseFixture _databaseFixture;

    public LoginEndpointTests(DatabaseFixture databaseFixture)
    {
        _databaseFixture = databaseFixture;
    }

    [Fact]
    public async Task LoginFailWithInvalidEmailAsync()
    {
        // Arrange
        var client = _databaseFixture.CreateClient();

        // Act
        var result = await client.PostAsJsonAsync("api/account/login", new LoginCommand {Email = "pauljean.ch", Password = "sdfsdsdfs"});

        // Assert
        result.StatusCode.ShouldBe(System.Net.HttpStatusCode.BadRequest);
    }
}