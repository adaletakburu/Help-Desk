using HelpDesk.Api.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace HelpDesk.Api.Application.Features.Queries.Demand.GetAll
{
    public class GetAllDemandQueryHandler : IRequestHandler<GetAllDemandQuery, List<GetAllDemandQueryResponse>>
    {
        private readonly IDemandRepository demandRepository;
        private readonly IHttpContextAccessor accessor;
        public GetAllDemandQueryHandler(IDemandRepository demandRepository, IHttpContextAccessor accessor)
        {
            this.demandRepository = demandRepository;
            this.accessor = accessor;
        }

        public async Task<List<GetAllDemandQueryResponse>> Handle(GetAllDemandQuery request, CancellationToken cancellationToken)
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
            });

            return await Task.FromResult(demandList.ToList());
        }
    }
}
