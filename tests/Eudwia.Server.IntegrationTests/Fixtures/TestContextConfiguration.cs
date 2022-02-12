using Eudwia.Server.Data.Contexts;

namespace Eudwia.Server.IntegrationTests.Fixtures;

public class TestContextConfiguration : IContextConfiguration
{
    public string ConnectionString { get; }

    public TestContextConfiguration(string connectionString)
    {
        ConnectionString = connectionString;
    }
}
