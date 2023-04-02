using FluentValidation;

namespace HelpDesk.Api.Application.Features.Commands.DemandMessage.Create
{
    public class CreateDemandMessageCommandValidator : AbstractValidator<CreateDemandMessageCommand>
    {
        public CreateDemandMessageCommandValidator()
        {
            RuleFor(i => i.UserId).NotNull();
            RuleFor(i => i.DemandId).NotNull();
            RuleFor(i => i.Message).NotNull();
        }
    }
}
