using FluentValidation;

namespace HelpDesk.Api.Application.Features.Commands.Demand.Update
{
    public class UpdateDemandCommandValidator : AbstractValidator<UpdateDemandCommand>
    {
        public UpdateDemandCommandValidator()
        {
            RuleFor(i => i.Id).NotEmpty();
            RuleFor(i => i.UserId).NotEmpty();
            RuleFor(i => i.Description).NotEmpty();
            RuleFor(i => i.Title).NotEmpty();
        }
    }
}
