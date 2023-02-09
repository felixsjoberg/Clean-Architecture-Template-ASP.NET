using Application.Common.Interfaces.Persistence.Commands;
using CA.Domain.Entities;
using CA.Infrastructure.DataContext;
using CA.Infrastructure.Persistence.Base;

namespace CA.Infrastructure.Persistence.Commands;


public class UserCommandRepository : CommandRepository<User>, IUserCommandRepository
{
    public UserCommandRepository(EfCoreContext context) : base(context)
    {

    }
}

