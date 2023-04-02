using HelpDesk.Api.Application.Interfaces.Repositories;
using HelpDesk.Api.Domain.Models;
using HelpDesk.Infrastructure.Persistance.Context;

namespace HelpDesk.Infrastructure.Persistance.Repositories
{
    public class DemandRepository : GenericRepository<Demand>, IDemandRepository
    {
        public DemandRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
