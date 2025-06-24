using Microsoft.Data.SqlClient;
using System.Data;
using UserManager.Data.Interfaces;

public class SqlConnectionFactory : IConnectionFactory
{
    private readonly IConfiguration _configuration;

    public SqlConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection CreateConnection()
    {
        var connectionString = _configuration.GetConnectionString("MyLocalConnection");
        return new SqlConnection(connectionString);
    }
}
