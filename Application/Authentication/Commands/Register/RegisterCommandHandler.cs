using Application.Authentication.Commands.Common;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using MediatR;

namespace Application.Authentication.Commands.Register;

public record RegisterCommand : IRequest<AuthenticationResponse>
{
    public string Email { get; init; } = null!;
    public string Password { get; init; } = null!;
}
 public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResponse>
 {
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public Task<AuthenticationResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
 }