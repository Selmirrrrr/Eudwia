using MosqueLife.Server.Data.Contexts;

namespace MosqueLife.Server.IntegrationTests.Fixtures;

public class TestContextConfiguration : IContextConfiguration
{
    public string ConnectionString { get; }

    public TestContextConfiguration(string connectionString)
    {
        ConnectionString = connectionString;
    }
}
