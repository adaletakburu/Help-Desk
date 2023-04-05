using AutoMapper;
using HelpDesk.Api.Application.Interfaces.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HelpDesk.Api.Application.Features.Queries.DemandMessage.GetByDemandId
{
    public class GetByDemandIdDemandMessageQueryHandler : IRequestHandler<GetByDemandIdDemandMessageQuery, List<GetByDemandIdDemandMessageQueryResponse>>
    {
        private readonly IDemandMessageRepository demandMessageRepository;
        private readonly IMapper mapper;

        public GetByDemandIdDemandMessageQueryHandler(IDemandMessageRepository demandMessageRepository, IMapper mapper)
        {
            this.demandMessageRepository = demandMessageRepository;
            this.mapper = mapper;
        }

        public async Task<List<GetByDemandIdDemandMessageQueryResponse>> Handle(GetByDemandIdDemandMessageQuery request, CancellationToken cancellationToken)
        {
            var response = demandMessageRepository.GetAll(i => i.DemandId == request.DemandId);
            var demandMessage = response.Select(i => new GetByDemandIdDemandMessageQueryResponse
            {
                Id = i.Id,
                DemandId = i.DemandId,
                UserId = i.UserId,
                Message = i.Message,
                CreatedDate = i.CreatedDate,
                UpdatedDate = i.UpdatedDate
            }).ToList();

            return await Task.FromResult(demandMessage);
        }
    }
}
