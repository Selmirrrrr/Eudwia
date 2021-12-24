using MosqueLife.Server;

namespace MosqueLife.Server;

public class TestContextConfiguration : IContextConfiguration
{
    public string ConnectionString { get; }

    public TestContextConfiguration(string connectionString)
    {
        ConnectionString = connectionString;
    }
}
