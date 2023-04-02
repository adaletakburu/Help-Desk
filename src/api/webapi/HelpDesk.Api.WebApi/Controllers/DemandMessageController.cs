using HelpDesk.Api.Application.Features.Commands.DemandMessage.Create;
using HelpDesk.Api.Application.Features.Commands.DemandMessage.Delete;
using HelpDesk.Api.Application.Features.Commands.DemandMessage.Update;
using HelpDesk.Api.Application.Features.Queries.DemandMessage.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DemandMessageController : BaseController
    {
        private readonly IMediator mediator;

        public DemandMessageController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDemandMessageCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] UpdateDemandMessageCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteDemandMessageCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }


        [HttpGet]
        [Route("{demandId}")]
        public async Task<IActionResult> GetByDemandId(Guid demandId)
        {
            var result = await mediator.Send(new GetByDemandIdDemandMessageQuery(demandId));
            return Ok(result);
        }

    }
}
