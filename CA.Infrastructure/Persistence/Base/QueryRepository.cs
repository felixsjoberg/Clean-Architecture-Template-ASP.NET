using CA.Application.Common.Interfaces.Persistence.Base;
using CA.Infrastructure.DataContext;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence.Base;
public class QueryRepository<T> : DapperContext,  IQueryRepository<T> where T : class
    {
        public QueryRepository(IConfiguration configuration)
            : base(configuration)
        {

        }

    public Task<IEnumerable<T>> GetAllAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> GetByEmail(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> GetByIdAsync(T entity)
    {
        throw new NotImplementedException();
    }
}