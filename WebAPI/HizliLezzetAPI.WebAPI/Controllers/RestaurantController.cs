using HizliLezzetAPI.Application.Features.Commands.Restaurant.Create;
using HizliLezzetAPI.Application.Features.Commands.Restaurant.DeleteById;
using HizliLezzetAPI.Application.Features.Commands.Restaurant.UpdateById;
using HizliLezzetAPI.Application.Features.Queries.Product.GetAll;
using HizliLezzetAPI.Application.Features.Queries.Product.GetById;
using HizliLezzetAPI.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HizliLezzetAPI.WebAPI.Controllers
{
    public class RestaurantController : BaseController
    {
        public RestaurantController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllRestaurantsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetRestaurantByIdQuery() { Id = id };

            return Ok(await mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRestaurantCommand createRestaurantCommand)
        {
            return Ok(await mediator.Send(createRestaurantCommand));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateRestaurantCommand updateRestaurantCommand)
        {
            if (id != updateRestaurantCommand.Id)
            {
                return BadRequest("The provided id in the URL does not match the id in the request body.");
            }

            return Ok(await mediator.Send(updateRestaurantCommand));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var query = new DeleteRestaurantByIdCommand() { Id = id };

            return Ok(await mediator.Send(query));
        }
    }
}
