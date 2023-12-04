using HizliLezzetAPI.Application.Features.Commands.Order.Create;
using HizliLezzetAPI.Application.Features.Commands.Order.DeleteById;
using HizliLezzetAPI.Application.Features.Commands.Order.UpdateById;
using HizliLezzetAPI.Application.Features.Commands.ProductCategory.UpdateById;
using HizliLezzetAPI.Application.Features.Queries.Order.GetAll;
using HizliLezzetAPI.Application.Features.Queries.Order.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HizliLezzetAPI.WebApi.Controllers
{
    public class OrderController : BaseController
    {
        public OrderController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllOrdersQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetOrderByIdQuery() { Id = id };

            return Ok(await mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOrderCommand createOrderCommand)
        {
            return Ok(await mediator.Send(createOrderCommand));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateOrderCommand updateOrderCommand)
        {
            if (id != updateOrderCommand.Id)
            {
                return BadRequest("The provided id in the URL does not match the id in the request body.");
            }

            return Ok(await mediator.Send(updateOrderCommand));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var query = new DeleteOrderByIdCommand() { Id = id };

            return Ok(await mediator.Send(query));
        }
    }
}
