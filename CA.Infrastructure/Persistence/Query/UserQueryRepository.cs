using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Persistence.Query;
using CA.Application.Common.Interfaces.Persistence.Base;
using CA.Domain.Entities;
using CA.Infrastructure.DataContext;
using CA.Infrastructure.Persistence.Base;
using Infrastructure.Persistence.Base;
using Microsoft.Extensions.Configuration;

namespace CA.Infrastructure.Persistence.Query;

public class UserQueryRepository : QueryRepository<User>, IUserQueryRepository
{
    public UserQueryRepository(IConfiguration configuration)
            : base(configuration)
        {

        }
}
