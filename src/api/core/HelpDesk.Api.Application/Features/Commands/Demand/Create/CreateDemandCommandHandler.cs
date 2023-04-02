using AutoMapper;
using HelpDesk.Api.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HelpDesk.Api.Application.Features.Commands.Demand.Create
{
    internal class CreateDemandCommandHandler : IRequestHandler<CreateDemandCommand, Guid>
    {
        private readonly IDemandRepository demandRepository;
        private readonly IMapper mapper;

        public CreateDemandCommandHandler(IDemandRepository demandRepository, IMapper mapper)
        {
            this.demandRepository = demandRepository;
            this.mapper = mapper;
        }

        public async Task<Guid> Handle(CreateDemandCommand request, CancellationToken cancellationToken)
        {
            var demand = mapper.Map<Domain.Models.Demand>(request);
            await demandRepository.AddAsync(demand);

            return demand.Id;
        }
    }
}
