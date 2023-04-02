using MediatR;
using System;

namespace HelpDesk.Api.Application.Features.Commands.Demand.Delete
{
    public class DeleteDemandCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
