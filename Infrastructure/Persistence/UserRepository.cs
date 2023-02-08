using System.Data;
using Application.Common.Interfaces.Persistence;
using Dapper;
using Domain.Entities;
using Infrastructure.DbContext;

namespace Infrastructure.Persistence;
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

    public async Task<User?> GetUserByEmail(string email)
    {
        using (var db = _Dappercontext.CreateConnection())
        {
            return await db.QuerySingleAsync<User>("GetUserByEmail", new { email }, commandType: CommandType.StoredProcedure);
        }
    }
}