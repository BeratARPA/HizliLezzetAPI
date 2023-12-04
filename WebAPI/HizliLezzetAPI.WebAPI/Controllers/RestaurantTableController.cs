using HizliLezzetAPI.Application.Features.Commands.RestaurantTable.Create;
using HizliLezzetAPI.Application.Features.Commands.RestaurantTable.DeleteById;
using HizliLezzetAPI.Application.Features.Commands.RestaurantTable.UpdateById;
using HizliLezzetAPI.Application.Features.Commands.RestaurantTableSection.UpdateById;
using HizliLezzetAPI.Application.Features.Queries.RestaurantTable.GetAll;
using HizliLezzetAPI.Application.Features.Queries.RestaurantTable.GetById;
using HizliLezzetAPI.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HizliLezzetAPI.WebAPI.Controllers
{
    public class RestaurantTableController : BaseController
    {
        public RestaurantTableController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllRestaurantTablesQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetRestaurantTableByIdQuery() { Id = id };

            return Ok(await mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRestaurantTableCommand createRestaurantTableCommand)
        {
            return Ok(await mediator.Send(createRestaurantTableCommand));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateRestaurantTableCommand updateRestaurantTableCommand)
        {
            if (id != updateRestaurantTableCommand.Id)
            {
                return BadRequest("The provided id in the URL does not match the id in the request body.");
            }

            return Ok(await mediator.Send(updateRestaurantTableCommand));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var query = new DeleteRestaurantTableByIdCommand() { Id = id };

            return Ok(await mediator.Send(query));
        }
    }
}
