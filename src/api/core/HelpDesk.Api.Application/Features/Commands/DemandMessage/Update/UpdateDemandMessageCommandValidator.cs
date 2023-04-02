using FluentValidation;

namespace HelpDesk.Api.Application.Features.Commands.DemandMessage.Update
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
