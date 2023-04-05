using FluentValidation;
using HelpDesk.Api.Application.Features.Commands.User.Register;

namespace HelpDesk.Api.Application.Validations.User
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(i => i.FirstName).NotEmpty();
            RuleFor(i => i.LastName).NotEmpty();
            RuleFor(i => i.UserName).NotEmpty();
            RuleFor(i => i.EmailAddress).NotNull().EmailAddress().WithMessage("A valid email is required");
            RuleFor(i => i.Password).NotEmpty().WithMessage("Your password cannot be empty")
                    .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                    .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                    .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                    .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.");

        }
    }
}
