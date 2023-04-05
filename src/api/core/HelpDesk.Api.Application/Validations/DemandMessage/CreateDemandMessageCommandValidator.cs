using FluentValidation;
using HelpDesk.Api.Application.Features.Commands.DemandMessage.Create;

namespace HelpDesk.Api.Application.Validations.DemandMessage
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
