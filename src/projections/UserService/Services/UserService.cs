using Dapper;
using HelpDesk.Common.Events.User;
using Microsoft.Data.SqlClient;
using System.Net.Mail;

namespace UserService.Services
{
    public class UserService
    {
        public  async Task<Guid> EmailById(UserEmailConfirmedEvent @event)
        {
            return @event.Id;       
        }
    }
}
