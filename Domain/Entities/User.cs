
namespace Domain.Entities;

public sealed class User
{
    public Guid UserId { get; set; } = Guid.NewGuid();
    public string Email { get; }
    public string Password { get; }
}
