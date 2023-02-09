using System.Data;
using CA.Application.Common.Interfaces.Persistence.Base;
using CA.Domain.Entities;
using CA.Infrastructure.DataContext;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence.Base;
public class QueryRepository<T> : DapperContext, IQueryRepository<T> where T : class
{
    public QueryRepository(IConfiguration configuration)
        : base(configuration)
    {

    }
    // Example database SQLite is without stored procedures.
    // Recommended to change database & use stored procedures.
    // https://github.com/DapperLib/Dapper#stored-procedures
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        using (var db = CreateConnection())
        {
            var query = "SELECT * FROM Users";
            return await db.QueryAsync<T>(query);
        }
    }

    public async Task<T> GetByEmail(string email)
    {
        using (var db = CreateConnection())
        {
            var query = "SELECT * FROM Users WHERE Email = @email";
            var result = await db.QuerySingleOrDefaultAsync<T>(query, new { email });
            return result;
        }
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        using (var db = CreateConnection())
        {
            var query = $"SELECT * FROM Users WHERE UserId = @id";
            return await db.QuerySingleOrDefaultAsync<T>(query, new { id });
        }
    }
}