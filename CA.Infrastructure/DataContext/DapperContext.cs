using System.Data;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace CA.Infrastructure.DataContext;
public class DapperContext
{
    private readonly IConfiguration _configuration;

    public DapperContext()
    {
    }
    protected DapperContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection CreateConnection()
    {
        string _connectionString = _configuration.GetConnectionString("DefaultConnection")!;
        return new SqliteConnection(_connectionString);
    }
}