using E_Commerce.Application.Mediator.Cart.Queries.GetAllPaymentMethods;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController(IMediator mediator) : ControllerBase
    {
        [HttpGet("PaymentMethods")]
        public async Task<IActionResult> GetPaymentMethod()
        {
            var response = await mediator.Send(new GetAllPaymentMethodsQuery());

            return response.Any() ? Ok(response) : NotFound();
        }


    }
}
