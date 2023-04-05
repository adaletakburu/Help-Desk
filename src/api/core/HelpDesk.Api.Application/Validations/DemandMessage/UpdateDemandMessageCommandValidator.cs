using FluentValidation;
using HelpDesk.Api.Application.Features.Commands.DemandMessage.Update;

namespace HelpDesk.Api.Application.Validations.DemandMessage
{
    public class UpdateDemandMessageCommandValidator : AbstractValidator<UpdateDemandMessageCommand>
    {
        public UpdateDemandMessageCommandValidator()
        {
            RuleFor(i => i.Id).NotNull();
            RuleFor(i => i.UserId).NotNull();
            RuleFor(i => i.DemandId).NotNull();
            RuleFor(i => i.Message).NotNull();

        }
    }
}
