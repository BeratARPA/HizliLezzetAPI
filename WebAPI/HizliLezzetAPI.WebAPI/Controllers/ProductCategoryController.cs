using HizliLezzetAPI.Application.Features.Commands.Product.UpdateById;
using HizliLezzetAPI.Application.Features.Commands.ProductCategory.Create;
using HizliLezzetAPI.Application.Features.Commands.ProductCategory.DeleteById;
using HizliLezzetAPI.Application.Features.Commands.ProductCategory.UpdateById;
using HizliLezzetAPI.Application.Features.Queries.ProductCategory.GetAll;
using HizliLezzetAPI.Application.Features.Queries.ProductCategory.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HizliLezzetAPI.WebApi.Controllers
{
    public class ProductCategoryController : BaseController
    {
        public ProductCategoryController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllProductCategoriesQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetProductCategoryByIdQuery() { Id = id };

            return Ok(await mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductCategoryCommand createProductCategoryCommand)
        {
            return Ok(await mediator.Send(createProductCategoryCommand));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateProductCategoryCommand updateProductCategoryCommand)
        {
            if (id != updateProductCategoryCommand.Id)
            {
                return BadRequest("The provided id in the URL does not match the id in the request body.");
            }

            return Ok(await mediator.Send(updateProductCategoryCommand));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var query = new DeleteProductCategoryByIdCommand() { Id = id };

            return Ok(await mediator.Send(query));
        }

    }
}
