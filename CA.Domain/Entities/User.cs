
namespace CA.Domain.Entities;

public class User
{
    //For simplicity sake, I'm using stringed-Guids for the Ids with Sqlite.
    //In a real world scenario, I would use int for the Ids with Sqlite.
    //I would use Guid for the Auth Ids with Sql Server.
    public string UserId { get; set; } = Guid.NewGuid().ToString();
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}
