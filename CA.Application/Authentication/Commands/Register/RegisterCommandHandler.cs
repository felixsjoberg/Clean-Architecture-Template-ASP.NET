using System;
using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Persistence.Commands;
using Application.Common.Interfaces.Persistence.Query;
using CA.Application.Authentication.Common;
using CA.Application.Common.Interfaces.Authentication;
using CA.Application.Common.Interfaces.Persistence;
using CA.Application.Common.Interfaces.Persistence.Base;
using CA.Domain.Entities;
using MediatR;

namespace CA.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResponse>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    private readonly IUserCommandRepository _userCommandRepository;
    private readonly IUserQueryRepository _userQueryRepository;

    public RegisterCommandHandler(IUserCommandRepository userRepository, IJwtTokenGenerator jwtTokenGenerator, IUserQueryRepository userQueryRepository)
    {

        _jwtTokenGenerator = jwtTokenGenerator;
        _userCommandRepository = userRepository;
        _userQueryRepository = userQueryRepository;
    }

    public async Task<AuthenticationResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Email = request.Email,
            Password = request.Password
        };
        if (await _userQueryRepository.GetByEmail(user.Email) is not null)
        {
            throw new Exception("User already exists");
        }

        var newUser = await _userCommandRepository.AddAsync(user);

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResponse
        (newUser.UserId,
        token);
    }
}