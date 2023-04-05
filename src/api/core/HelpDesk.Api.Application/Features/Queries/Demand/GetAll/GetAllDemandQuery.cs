using HelpDesk.Common.Pagination.Filter;
using HelpDesk.Common.Pagination.Wrappers;
using MediatR;
using System;

namespace HelpDesk.Api.Application.Features.Queries.Demand.GetAll
{
    public class GetAllDemandQuery : PaginationFilter, IRequest<PagedResponse<GetAllDemandQueryResponse>>
    {
        public Guid UserId { get; set; }
        public string Path { get; set; }
        
        public GetAllDemandQuery(Guid userId, string path, int pageNumber, int pageSize)
        {
            UserId = userId;
            Path = path;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

    }
}
