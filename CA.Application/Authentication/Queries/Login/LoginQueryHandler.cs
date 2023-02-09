using Application.Common.Interfaces.Persistence.Commands;
using Application.Common.Interfaces.Persistence.Query;
using CA.Application.Authentication.Common;
using CA.Application.Common.Interfaces.Authentication;
using CA.Domain.Entities;
using MediatR;

namespace CA.Application.Authentication.Queries.Login;

public class LoginQueryHandler :
    IRequestHandler<LoginQuery, AuthenticationResponse>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    private readonly IUserCommandRepository _userCommandRepository;
    private readonly IUserQueryRepository _userQueryRepository;


    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserQueryRepository userQueryRepository, IUserCommandRepository userCommandRepository, IJwtTokenGenerator jwtTokenGenerator2)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userQueryRepository = userQueryRepository;
        _userCommandRepository = userCommandRepository;
        _jwtTokenGenerator = jwtTokenGenerator2;
    }

    public async Task<AuthenticationResponse> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        var user = await _userQueryRepository.GetByEmail(query.Email);

        if (user is null)
        {
            throw new Exception("User does not exist");
        }

        if (user.Password != query.Password)
        {
            throw new Exception("Invalid password");
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResponse(
            user.UserId,
            token);
    }
}
