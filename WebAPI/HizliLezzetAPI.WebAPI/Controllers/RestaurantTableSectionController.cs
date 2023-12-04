using HizliLezzetAPI.Application.Features.Commands.RestaurantTableSection.Create;
using HizliLezzetAPI.Application.Features.Commands.RestaurantTableSection.DeleteById;
using HizliLezzetAPI.Application.Features.Commands.RestaurantTableSection.UpdateById;
using HizliLezzetAPI.Application.Features.Commands.Ticket.UpdateById;
using HizliLezzetAPI.Application.Features.Queries.RestaurantTableSection.GetAll;
using HizliLezzetAPI.Application.Features.Queries.RestaurantTableSection.GetById;
using HizliLezzetAPI.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HizliLezzetAPI.WebAPI.Controllers
{
    public class RestaurantTableSectionController : BaseController
    {
        public RestaurantTableSectionController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllRestaurantTableSectionsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetRestaurantTableSectionByIdQuery() { Id = id };

            return Ok(await mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRestaurantTableSectionCommand createRestaurantTableSectionCommand)
        {
            return Ok(await mediator.Send(createRestaurantTableSectionCommand));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateRestaurantTableSectionCommand updateRestaurantTableSectionCommand)
        {
            if (id != updateRestaurantTableSectionCommand.Id)
            {
                return BadRequest("The provided id in the URL does not match the id in the request body.");
            }

            return Ok(await mediator.Send(updateRestaurantTableSectionCommand));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var query = new DeleteRestaurantTableSectionByIdCommand() { Id = id };

            return Ok(await mediator.Send(query));
        }
    }
}
