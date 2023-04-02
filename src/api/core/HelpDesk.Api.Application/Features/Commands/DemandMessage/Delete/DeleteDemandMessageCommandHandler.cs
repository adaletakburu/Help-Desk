using HelpDesk.Api.Application.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HelpDesk.Api.Application.Features.Commands.DemandMessage.Delete
{
    public class DeleteDemandMessageCommandHandler : IRequestHandler<DeleteDemandMessageCommand, bool>
    {
        private readonly IDemandMessageRepository demandMessageRepository;

        public DeleteDemandMessageCommandHandler(IDemandMessageRepository demandMessageRepository)
        {
            this.demandMessageRepository = demandMessageRepository;
        }

        public async Task<bool> Handle(DeleteDemandMessageCommand request, CancellationToken cancellationToken)
        {
            await demandMessageRepository.DeleteAsync(request.Id);
            return true;
        }
    }
}
