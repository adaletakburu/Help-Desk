using HelpDesk.Api.Application.Interfaces.Repositories;
using HelpDesk.Api.Domain.Models;
using HelpDesk.Infrastructure.Persistance.Context;

namespace HelpDesk.Infrastructure.Persistance.Repositories
{
    public class DemandMessageRepository : GenericRepository<DemandMessage>, IDemandMessageRepository
    {
        public DemandMessageRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
