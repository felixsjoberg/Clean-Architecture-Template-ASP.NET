using CA.Domain.Entities;

namespace CA.Application.Common.Interfaces.Authentication;
public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}