using CA.Application.Authentication.Commands.Common;
using CA.Application.Common.Interfaces.Authentication;
using CA.Application.Common.Interfaces.Persistence;
using MediatR;

namespace CA.Application.Authentication.Commands.Register;

public record RegisterCommand : IRequest<AuthenticationResponse>
{
    public string Email { get; init; } = null!;
    public string Password { get; init; } = null!;
}
 public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResponse>
 {
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public Task<AuthenticationResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
 }