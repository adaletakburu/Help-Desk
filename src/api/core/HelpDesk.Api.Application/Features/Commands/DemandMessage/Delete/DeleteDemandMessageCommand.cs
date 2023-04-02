using MediatR;
using System;

namespace HelpDesk.Api.Application.Features.Commands.DemandMessage.Delete
{
    public class DeleteDemandMessageCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
