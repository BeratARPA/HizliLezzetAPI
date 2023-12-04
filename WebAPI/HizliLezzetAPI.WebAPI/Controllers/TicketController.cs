using HizliLezzetAPI.Application.Features.Commands.Restaurant.UpdateById;
using HizliLezzetAPI.Application.Features.Commands.Ticket.Create;
using HizliLezzetAPI.Application.Features.Commands.Ticket.DeleteById;
using HizliLezzetAPI.Application.Features.Commands.Ticket.UpdateById;
using HizliLezzetAPI.Application.Features.Queries.Ticket.GetAll;
using HizliLezzetAPI.Application.Features.Queries.Ticket.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HizliLezzetAPI.WebApi.Controllers
{
    public class TicketController : BaseController
    {
        public TicketController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllTicketsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetTicketByIdQuery() { Id = id };

            return Ok(await mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTicketCommand createTicketCommand)
        {
            return Ok(await mediator.Send(createTicketCommand));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateTicketCommand updateTicketCommand)
        {
            if (id != updateTicketCommand.Id)
            {
                return BadRequest("The provided id in the URL does not match the id in the request body.");
            }

            return Ok(await mediator.Send(updateTicketCommand));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var query = new DeleteTicketByIdCommand() { Id = id };

            return Ok(await mediator.Send(query));
        }
    }
}
