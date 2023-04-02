using HelpDesk.Api.Domain.Models;
using MediatR;
using System;

namespace HelpDesk.Api.Application.Features.Commands.User.Register
{
    public class RegisterCommand : IRequest<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
