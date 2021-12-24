using MosqueLife.Server.IntegrationTests.Fixtures;
using Shouldly;
using System.Net.Http.Json;
using MosqueLife.Shared.Features.Account.Login;
using Xunit;

namespace MosqueLife.Server.IntegrationTests.Features.Account.Login;

[Collection(DatabaseTestsCollection.CollectionName)]
public class LoginEndpointTests 
{
    private readonly DatabaseFixture _databaseFixture;

    public LoginEndpointTests(DatabaseFixture  databaseFixture)
    {
        _databaseFixture = databaseFixture;
    }

    [Fact]
    public async Task LoginFailWithInvalidEmailAsync()
    {
        // Arrange
        var client = _databaseFixture.CreateClient();

        // Act
        var result = await client.PostAsJsonAsync("api/account/login", new LoginCommand { Email = "pauljean.ch", Password = "sdfsdsdfs", RememberMe = true });

        // Assert
        result.StatusCode.ShouldBe(System.Net.HttpStatusCode.BadRequest);
    }
}
