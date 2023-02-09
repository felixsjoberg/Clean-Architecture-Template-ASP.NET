using CA.Application.Authentication.Common;
using MediatR;
namespace CA.Application.Authentication.Commands.Register;
public record RegisterCommand(
    string Email,
    string Password): IRequest<AuthenticationResponse>;