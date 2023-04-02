using MediatR;

namespace HelpDesk.Api.Application.Features.Commands.User.Login
{
    public class LoginCommand : IRequest<LoginCommandResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }


    }
}
