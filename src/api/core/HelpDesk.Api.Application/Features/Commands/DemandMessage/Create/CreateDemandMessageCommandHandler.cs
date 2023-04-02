using AutoMapper;
using HelpDesk.Api.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HelpDesk.Api.Application.Features.Commands.DemandMessage.Create
{
    public class CreateDemandMessageCommandHandler : IRequestHandler<CreateDemandMessageCommand, Guid>
    {
        private readonly IDemandMessageRepository demandMessageRepository;
        private readonly IMapper mapper;

        public CreateDemandMessageCommandHandler(IMapper mapper, IDemandMessageRepository demandMessageRepository)
        {

            this.mapper = mapper;
            this.demandMessageRepository = demandMessageRepository;
        }

        public async Task<Guid> Handle(CreateDemandMessageCommand request, CancellationToken cancellationToken)
        {
            var demandMessage = mapper.Map<Domain.Models.DemandMessage>(request);
            await demandMessageRepository.AddAsync(demandMessage);

            return demandMessage.Id;
        }
    }
}
