using CA.Application.Common.Interfaces.Persistence.Base;
using CA.Domain.Entities;

namespace Application.Common.Interfaces.Persistence;
public interface IUserRepository : IQueryRepository<User>, ICommandRepository<User>
{
    
}