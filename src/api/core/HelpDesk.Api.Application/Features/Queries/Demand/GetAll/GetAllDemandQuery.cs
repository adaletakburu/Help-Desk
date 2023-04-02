using MediatR;
using System;
using System.Collections.Generic;

namespace HelpDesk.Api.Application.Features.Queries.Demand.GetAll
{
    public class GetAllDemandQuery : IRequest<List<GetAllDemandQueryResponse>>
    {
        public Guid UserId { get; set; }

        public GetAllDemandQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
