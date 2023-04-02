using HelpDesk.Api.Domain.Models;
using System;
using System.Collections.Generic;

namespace HelpDesk.Api.Application.Features.Queries.Demand.GetById
{
    public class GetByIdDemandQueryResponse //: HelpDesk.Api.Domain.Models.Demand
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Status Status { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<Domain.Models.DemandMessage> DemandMessages { get; set; }

    }
}
