using HelpDesk.Api.Domain.Models;
using MediatR;
using System;

namespace HelpDesk.Api.Application.Features.Commands.Demand.Create
{
    public class CreateDemandCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Status Status { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
