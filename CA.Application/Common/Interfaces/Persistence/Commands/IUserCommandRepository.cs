using CA.Application.Common.Interfaces.Persistence.Base;
using CA.Domain.Entities;

namespace Application.Common.Interfaces.Persistence.Commands;
public interface IUserCommandRepository : ICommandRepository<User>
{
    
}