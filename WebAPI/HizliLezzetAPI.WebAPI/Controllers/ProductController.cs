using HizliLezzetAPI.Application.Features.Commands.CreateProduct;
using HizliLezzetAPI.Application.Features.Queries.GetAllProducts;
using HizliLezzetAPI.Application.Features.Queries.GetProductById;
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
    }
}
