using HelpDesk.Api.Domain.Models;
using MediatR;
using System;

namespace HelpDesk.Api.Application.Features.Commands.Demand.Update
{
    public class UpdateDemandCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Status Status { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

    }
}
