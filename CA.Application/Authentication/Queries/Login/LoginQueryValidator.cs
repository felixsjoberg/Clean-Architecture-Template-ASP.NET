using CA.Application.Authentication.Queries.Login;
using FluentValidation;

namespace Application.Authentication.Queries.Login;
public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}