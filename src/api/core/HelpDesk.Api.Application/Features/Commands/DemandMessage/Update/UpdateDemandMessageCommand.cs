using MediatR;
using System;

namespace HelpDesk.Api.Application.Features.Commands.DemandMessage.Update
{
    public class UpdateDemandMessageCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid DemandId { get; set; }
        public string Message { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
