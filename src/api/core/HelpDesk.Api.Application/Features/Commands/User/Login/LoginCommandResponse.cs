namespace HelpDesk.Api.Application.Features.Commands.User.Login
{
    public class LoginCommandResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Token { get; set; }
    }
}
