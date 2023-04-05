using FluentValidation;
using HelpDesk.Api.Application.Features.Commands.User.Login;

namespace HelpDesk.Api.Application.Validations.User
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(i => i.UserName).NotEmpty();
            RuleFor(i => i.Password).NotEmpty().WithMessage("Your password cannot be empty");
        }
    }
}
