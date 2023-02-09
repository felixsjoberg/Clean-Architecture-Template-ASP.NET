using CA.Application.Authentication.Common;
using MediatR;

namespace CA.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<AuthenticationResponse>;

