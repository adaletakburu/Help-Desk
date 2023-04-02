using HelpDesk.Api.Application.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HelpDesk.Api.Application.Features.Commands.Demand.Delete
{
    public class DeleteDemandCommandHandler : IRequestHandler<DeleteDemandCommand, bool>
    {
        private readonly IDemandRepository demandRepository;

        public DeleteDemandCommandHandler(IDemandRepository demandRepository)
        {
            this.demandRepository = demandRepository;
        }

        public async Task<bool> Handle(DeleteDemandCommand request, CancellationToken cancellationToken)
        {
            var demand = await demandRepository.GetAsync(i => i.Id == request.Id);
            await demandRepository.DeleteAsync(demand.Id);

            return true;
        }
    }
}
