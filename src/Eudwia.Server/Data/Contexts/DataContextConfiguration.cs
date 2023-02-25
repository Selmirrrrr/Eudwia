namespace Eudwia.Server.Data.Contexts;

public class DataContextConfiguration : IContextConfiguration
{
    public DataContextConfiguration(IConfiguration config)
    {
        ConnectionString = config.GetConnectionString("DefaultConnection");
    }

    public string ConnectionString { get; }
}

public interface IContextConfiguration
{
    string ConnectionString { get; }
}