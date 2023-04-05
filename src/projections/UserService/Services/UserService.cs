using HelpDesk.Common.Events.User;

namespace UserService.Services
{
    public class UserService
    {
        public async Task<Guid> EmailById(UserEmailConfirmedEvent @event)
        {
            return @event.Id;
        }
    }
}
