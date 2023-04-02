using FluentValidation;

namespace HelpDesk.Api.Application.Features.Commands.Demand.Create
{
    public class CreateDemandCommandValidator : AbstractValidator<CreateDemandCommand>
    {
        public CreateDemandCommandValidator()
        {
            RuleFor(i => i.UserId).NotEmpty();
            RuleFor(i => i.Title).NotEmpty();
            RuleFor(i => i.Description).NotEmpty();
            RuleFor(i => i.Status).NotNull();
        }
    }
}
