using Xunit;

namespace MosqueLife.Server.IntegrationTests.Fixtures
{
    [CollectionDefinition(CollectionName)]
    public class DatabaseTestsCollection : ICollectionFixture<DatabaseFixture>
    {
        public const string CollectionName = "Database containers collection";
    }
}