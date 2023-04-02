using HelpDesk.Api.Application.Features.Commands.User.ConfirmEmail;
using HelpDesk.Api.Application.Features.Commands.User.Login;
using HelpDesk.Api.Application.Features.Commands.User.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace HelpDesk.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IMediator mediator;
        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("Confirm")]
        public async Task<IActionResult> ConfirmEmail(Guid id)
        {
            var guid = await mediator.Send(new ConfirmEmailCommand() { ConfirmationId = id });
            return Ok(guid);
        }

    }
}
