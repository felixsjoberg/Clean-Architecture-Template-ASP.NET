using Application.Authentication.Commands.Common;
using MediatR;

namespace Application.Authentication.Queries.Login;

public record LoginQuery : IRequest<AuthenticationResponse>
{
    public string Email { get; init; } = null!;
    public string Password { get; init; } = null!;
}
