using Microsoft.EntityFrameworkCore;

namespace MosqueLife.Server;

public class DataContextConfiguration : IContextConfiguration
{
    public DataContextConfiguration(IConfiguration config)
    {
        ConnectionString = config.GetConnectionString("PostgreSQL");
    }

    public string ConnectionString { get; }
}

public interface IContextConfiguration
{
    string ConnectionString { get; }
}
