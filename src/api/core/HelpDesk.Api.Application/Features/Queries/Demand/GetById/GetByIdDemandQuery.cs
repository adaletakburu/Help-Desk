using MediatR;
using System;

namespace HelpDesk.Api.Application.Features.Queries.Demand.GetById
{
    public class GetByIdDemandQuery : IRequest<GetByIdDemandQueryResponse>
    {
        public Guid Id { get; set; }

        public GetByIdDemandQuery(Guid ıd)
        {
            Id = ıd;
        }
    }
}
