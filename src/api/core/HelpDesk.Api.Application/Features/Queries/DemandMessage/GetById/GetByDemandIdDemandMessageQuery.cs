using MediatR;
using System;
using System.Collections.Generic;

namespace HelpDesk.Api.Application.Features.Queries.DemandMessage.GetById
{
    public class GetByDemandIdDemandMessageQuery : IRequest<List<GetByDemandIdDemandMessageQueryResponse>>
    {
        public Guid DemandId { get; set; }

        public GetByDemandIdDemandMessageQuery(Guid demandId)
        {
            DemandId = demandId;
        }
    }
}
