using HelpDesk.Api.Application.Interfaces.Repositories;
using HelpDesk.Common.Pagination.Extensions;
using HelpDesk.Common.Pagination.Wrappers;
using HelpDesk.Common.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace HelpDesk.Api.Application.Features.Queries.Demand.GetAll
{
    public class GetAllDemandQueryHandler : IRequestHandler<GetAllDemandQuery, PagedResponse<GetAllDemandQueryResponse>>
    {
        private readonly IDemandRepository demandRepository;
        private readonly IHttpContextAccessor accessor;
        private readonly IUriService uriService;

        public GetAllDemandQueryHandler(IDemandRepository demandRepository, IHttpContextAccessor accessor, IUriService uriService)
        {
            this.demandRepository = demandRepository;
            this.accessor = accessor;
            this.uriService = uriService;
        }


        Task<PagedResponse<GetAllDemandQueryResponse>> IRequestHandler<GetAllDemandQuery, PagedResponse<GetAllDemandQueryResponse>>.Handle(GetAllDemandQuery request, CancellationToken cancellationToken)
        {
            var role = accessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
            var demands = demandRepository.GetAll();
            if (role is "User")
            {
                demands = demands.Where(i => i.UserId == request.UserId);
            }

            var demandList = demands.Select(i => new GetAllDemandQueryResponse()
            {
                Id = i.Id,
                UserId = i.UserId,
                Description = i.Description,
                Status = i.Status,
                Title = i.Title,
                CreatedDate = i.CreatedDate,
                UpdatedDate = i.UpdatedDate
            }).GetPaged(request.PageNumber, request.PageSize, uriService, request.Path);

            return demandList;
        }
    }
}
