using HizliLezzetAPI.Application.Features.Commands.Product.Create;
using HizliLezzetAPI.Application.Features.Commands.Product.DeleteById;
using HizliLezzetAPI.Application.Features.Commands.Product.UpdateById;
using HizliLezzetAPI.Application.Features.Queries.Product.GetAll;
using HizliLezzetAPI.Application.Features.Queries.Product.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HizliLezzetAPI.WebApi.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllProductsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetProductByIdQuery() { Id = id };

            return Ok(await mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductCommand createProductCommand)
        {
            return Ok(await mediator.Send(createProductCommand));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProductCommand updateProductCommand)
        {
            return Ok(await mediator.Send(updateProductCommand));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var query = new DeleteProductByIdCommand() { Id = id };

            return Ok(await mediator.Send(query));
        }

    }
}
