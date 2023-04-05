using HelpDesk.Api.Application.Features.Commands.Demand.Create;
using HelpDesk.Api.Application.Features.Commands.Demand.Delete;
using HelpDesk.Api.Application.Features.Commands.Demand.Update;
using HelpDesk.Api.Application.Features.Queries.Demand.GetAll;
using HelpDesk.Api.Application.Features.Queries.Demand.GetById;
using HelpDesk.Common.Pagination.Filter;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DemandController : BaseController
    {
        private readonly IMediator mediator;

        public DemandController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            var result = await mediator.Send(new GetAllDemandQuery(UserId, Request.Path.Value, filter.PageNumber, filter.PageSize));
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await mediator.Send(new GetByIdDemandQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDemandCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] UpdateDemandCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteDemandCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

    }
}
