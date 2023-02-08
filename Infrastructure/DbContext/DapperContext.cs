using System.Data;
using System.Data.SqlClient;
using Infrastructure.Presistence;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.DbContext;
public class DapperContext
{
   private readonly IConfiguration _configuration;

        protected DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            string _connectionString = _configuration.GetConnectionString("DefaultConnection");
            return new SqliteConnection(_connectionString);
        }
}