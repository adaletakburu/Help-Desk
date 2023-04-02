using HelpDesk.Api.Domain.Models;
using System;

namespace HelpDesk.Api.Application.Features.Queries.Demand.GetAll
{
    public class GetAllDemandQueryResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Status Status { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
