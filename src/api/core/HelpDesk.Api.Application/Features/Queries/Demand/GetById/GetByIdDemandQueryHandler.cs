using AutoMapper;
using HelpDesk.Api.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HelpDesk.Api.Application.Features.Queries.Demand.GetById
{
    public class GetByIdDemandQueryHandler : IRequestHandler<GetByIdDemandQuery, GetByIdDemandQueryResponse>
    {
        private readonly IDemandRepository demandRepository;
        private readonly IMapper mapper;

        public GetByIdDemandQueryHandler(IDemandRepository demandRepository, IMapper mapper)
        {
            this.demandRepository = demandRepository;
            this.mapper = mapper;
        }

        public async Task<GetByIdDemandQueryResponse> Handle(GetByIdDemandQuery request, CancellationToken cancellationToken)
        {
            var res = demandRepository.AsQueryable();
            res = res.Include(i => i.DemandMessages)
                .Where(i => i.Id == request.Id);

            var demand = res.Select(i => new GetByIdDemandQueryResponse
            {
                Id = i.Id,
                Title = i.Title,
                Description = i.Description,
                UserId = i.UserId,
                Status = i.Status,
                CreatedDate = i.CreatedDate,
                UpdatedDate = i.UpdatedDate,
                DemandMessages = i.DemandMessages,

            }).FirstOrDefault();
            return await Task.FromResult(demand);
        }
    }
}
