using System;

namespace HelpDesk.Api.Application.Features.Queries.DemandMessage.GetById
{
    public class GetByDemandIdDemandMessageQueryResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid DemandId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
