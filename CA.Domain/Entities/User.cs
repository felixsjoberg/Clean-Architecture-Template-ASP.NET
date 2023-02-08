
namespace CA.Domain.Entities;

public class User
{
    public Guid UserId { get; set; } = Guid.NewGuid();
    public string Email { get; }
    public string Password { get; }
}
