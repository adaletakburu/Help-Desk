using AutoMapper;
using HelpDesk.Api.Application.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HelpDesk.Api.Application.Features.Commands.Demand.Update
{
    public class UpdateDemandCommandHandler : IRequestHandler<UpdateDemandCommand, bool>
    {
        private readonly IDemandRepository demandRepository;
        private readonly IMapper mapper;

        public UpdateDemandCommandHandler(IDemandRepository demandRepository, IMapper mapper)
        {
            this.demandRepository = demandRepository;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(UpdateDemandCommand request, CancellationToken cancellationToken)
        {
            var demand = mapper.Map<Domain.Models.Demand>(request);
            await demandRepository.UpdateAsync(demand);
            return true;

        }
    }
}
