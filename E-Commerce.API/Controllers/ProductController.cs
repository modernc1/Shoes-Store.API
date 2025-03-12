using Azure;
using E_Commerce.Application.Mediator.Products.Commands.CreateProduct;
using E_Commerce.Application.Mediator.Products.Commands.DeleteImageById;
using E_Commerce.Application.Mediator.Products.Commands.DeleteProduct;
using E_Commerce.Application.Mediator.Products.Commands.UpdateProduct;
using E_Commerce.Application.Mediator.Products.Queries.GetAllProducts;
using E_Commerce.Application.Mediator.Products.Queries.GetImages;
using E_Commerce.Application.Mediator.Products.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery]GetAllProductsQuery query)
        {
            var response = await mediator.Send(query);
            return response.Products.Any() ? Ok(response) : NotFound();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetProductById([FromRoute]GetProductByIdQuery query)
        {
            var response = await mediator.Send(query);
            
            return response is not null ? Ok(response) : NotFound();
        }

        [HttpGet("productImage/{Id}")]
        public async Task<IActionResult> GetImagesByProductId([FromRoute] GetImagesByProductIdQuery query)
		{
            var response = await mediator.Send(query);

			return response is not null ? Ok(response) : NotFound();
		}

		[HttpDelete("productImage/{Id}")]
		public async Task<IActionResult> DeleteImageById([FromRoute] DeleteImageByIdCommand command)
		{
			var response = await mediator.Send(command);

			return response is not null ? Ok(response) : NotFound();
		}

		[HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm]CreateProductCommand command)
        {
            
            var response = await mediator.Send(command);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateProduct([FromForm]UpdateProductCommand command, [FromRoute] Guid Id)
        {
            var response = await mediator.Send(command);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute]DeleteProductCommand command)
        {
            var response = await mediator.Send(command);
            return response.Success ? Ok(response) : BadRequest(response);
        }

    }
}
