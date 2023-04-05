using MediatR;
using System;

namespace HelpDesk.Api.Application.Features.Commands.User.ConfirmEmail
{
    public class ConfirmEmailCommand : IRequest<bool>
    {
        public Guid ConfirmationId { get; set; }

    }
}
