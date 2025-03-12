using E_Commerce.Application.Mediator.Cart.Commands.CreateCheckout;
using E_Commerce.Application.Mediator.Cart.Queries.GetChargeStatus;
using E_Commerce.Application.Mediator.Cart.Queries.GetCheckoutDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CartController(IMediator mediator) : ControllerBase
    {
        [HttpPost("CreateCheckout")]
        public async Task<IActionResult> CreateCheckout(CreateCheckoutCommand command)
        {
            var response = await mediator.Send(command);
            return response != null ? Ok(response) : BadRequest(response);
        }

        [HttpGet("PaymentStatus/{charge_id}")]
        public async Task<IActionResult> RetrivePaymentStatus([FromRoute] GetChargeStatusQuery query)
        {
            string response = await mediator.Send(query);
            return Ok(new { status =  response});
        }

        [HttpGet("CheckoutDetails/{charge_id}")]
        public async Task<IActionResult> GetCheckoutDetails([FromRoute] GetCheckoutDetailsQuery query)
        {
            var response = await mediator.Send(query);
            return Ok(response);
        }
    }
}
