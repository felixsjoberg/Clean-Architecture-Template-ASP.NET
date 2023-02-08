using Application.Common.Interfaces.Persistence;
using CA.Domain.Entities;
using CA.Infrastructure.DataContext;

namespace CA.Infrastructure.Persistence;
public class UserRepository : IUserRepository
{
    private readonly DapperContext _Dappercontext;
    private readonly EfCoreContext _EfCorecontext;
    public UserRepository(EfCoreContext efcorecontext, DapperContext dappercontext)
    {
        _EfCorecontext = efcorecontext;
        _Dappercontext = dappercontext;
    }
    public void Add(User user)
    {
        _EfCorecontext.Add(user);
    }

    public Task<User> AddAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAllAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByEmail(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByIdAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }
}