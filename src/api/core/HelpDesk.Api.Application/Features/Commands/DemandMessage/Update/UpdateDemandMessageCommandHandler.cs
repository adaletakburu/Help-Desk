using AutoMapper;
using HelpDesk.Api.Application.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HelpDesk.Api.Application.Features.Commands.DemandMessage.Update
{
    public class UpdateDemandMessageCommandHandler : IRequestHandler<UpdateDemandMessageCommand, bool>
    {
        private readonly IDemandMessageRepository demandMessageRepository;
        private readonly IMapper mapper;

        public UpdateDemandMessageCommandHandler(IDemandMessageRepository demandMessageRepository, IMapper mapper)
        {
            this.demandMessageRepository = demandMessageRepository;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(UpdateDemandMessageCommand request, CancellationToken cancellationToken)
        {
            var demandMessage = mapper.Map<Domain.Models.DemandMessage>(request);
            await demandMessageRepository.UpdateAsync(demandMessage);
            return true;
        }
    }
}
