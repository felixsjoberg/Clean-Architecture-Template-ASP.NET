using Domain.Entities;

namespace Application.Common.Interfaces.Persistence;
public interface IUserRepository
{
    void Add(User user);
    Task<User?> GetUserByEmail(string email);
}