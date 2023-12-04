using HizliLezzetAPI.Application.Features.Commands.Payment.Create;
using HizliLezzetAPI.Application.Features.Commands.Payment.DeleteById;
using HizliLezzetAPI.Application.Features.Commands.Payment.UpdateById;
using HizliLezzetAPI.Application.Features.Queries.Payment.GetAll;
using HizliLezzetAPI.Application.Features.Queries.Payment.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HizliLezzetAPI.WebApi.Controllers
{
    public class PaymentController : BaseController
    {
        public PaymentController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllPaymentsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetPaymentByIdQuery() { Id = id };

            return Ok(await mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePaymentCommand createPaymentCommand)
        {
            return Ok(await mediator.Send(createPaymentCommand));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdatePaymentCommand updatePaymentCommand)
        {
            if (id != updatePaymentCommand.Id)
            {
                return BadRequest("The provided id in the URL does not match the id in the request body.");
            }

            return Ok(await mediator.Send(updatePaymentCommand));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var query = new DeletePaymentByIdCommand() { Id = id };

            return Ok(await mediator.Send(query));
        }
    }
}
