using CA.Application.Authentication.Commands.Register;
using FluentValidation;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}