using HelpDesk.Api.Application.Interfaces.Repositories;
using HelpDesk.Api.Domain.Models;
using HelpDesk.Infrastructure.Persistance.Context;

namespace HelpDesk.Infrastructure.Persistance.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
