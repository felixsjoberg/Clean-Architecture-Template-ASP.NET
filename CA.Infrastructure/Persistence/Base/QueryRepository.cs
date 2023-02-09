using System.Data;
using CA.Application.Common.Interfaces.Persistence.Base;
using CA.Domain.Entities;
using CA.Infrastructure.DataContext;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence.Base;
public class QueryRepository<T> : DapperContext, IQueryRepository<T> where T : class
{
    private readonly DapperContext _context;

    public QueryRepository(DapperContext context)
    {
        _context = context;

    }
    public QueryRepository(IConfiguration configuration)
        : base(configuration)
    {
        
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        using (var db = _context.CreateConnection())
        {
            return await db.QueryAsync<T>("GetAll", commandType: CommandType.StoredProcedure);
        }
    }

    public async Task<T> GetByEmail(string email)
    {
        using (var db = _context.CreateConnection())
        {
            return await db.QuerySingleOrDefaultAsync<T>("GetByEmail", new { email }, commandType: CommandType.StoredProcedure);
        }
    }

    public async Task<T> GetByIdAsync(int id)
    {
        using (var db = _context.CreateConnection())
        {
            return await db.QuerySingleOrDefaultAsync<T>("GetById", new { id }, commandType: CommandType.StoredProcedure);
        }
    }
}