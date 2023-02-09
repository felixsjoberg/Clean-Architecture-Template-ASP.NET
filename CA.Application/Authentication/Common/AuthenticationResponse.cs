namespace CA.Application.Authentication.Common
{
    public record AuthenticationResponse(Guid UserId, string Token);
}