using MediatR;
using System;

namespace HelpDesk.Api.Application.Features.Commands.DemandMessage.Create
{
    public class CreateDemandMessageCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid DemandId { get; set; }
        public string Message { get; set; }
    }
}
