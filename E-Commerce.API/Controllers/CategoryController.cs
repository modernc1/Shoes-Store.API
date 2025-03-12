using E_Commerce.Application.Mediator.Categories.Commands.CreateCategory;
using E_Commerce.Application.Mediator.Categories.Commands.DeleteCategory;
using E_Commerce.Application.Mediator.Categories.Commands.UpdateCategory;
using E_Commerce.Application.Mediator.Categories.Queries.GetAllCategories;
using E_Commerce.Application.Mediator.Categories.Queries.GetCategoryById;
using E_Commerce.Application.Mediator.Categories.Queries.GetGenders;
using E_Commerce.Application.Mediator.Categories.Queries.GetProductByCategory;
using E_Commerce.Domain.Static;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        //[Authorize(Roles = StaticData.UserRole)]
        public async Task<IActionResult> GetAllCategories()
        {
            var response = await mediator.Send(new GetAllCategoriesQuery());
            return response.Any() ? Ok(response) : NotFound();
        }

        [HttpGet("Products/{CategoryId:guid}")]
        public async Task<IActionResult> GetProductsByCategory([FromRoute]GetProductByCategoryQuery query)
        {
            var response = await mediator.Send(query);

            return response.Any() ? Ok(response) : NotFound(response);
        }
        [HttpGet("Genders/{Loaded:bool}")]
        public async Task<IActionResult> GetGenderCategories([FromRoute]GetGendersQuery query)
        {
            var response = await mediator.Send(query);
			return response.Any() ? Ok(response) : NotFound(response);
		}

		[HttpGet("{Id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] GetCategoryByIdQuery query)
        {
            var response = await mediator.Send(query);

            return response is not null ? Ok(response) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromForm] CreateCategoryCommand command)
        {
            var response = await mediator.Send(command);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateCategory([FromForm] UpdateCategoryCommand command, [FromRoute] Guid Id)
        {
            command.Id = Id;
            var response = await mediator.Send(command);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] DeleteCategoryCommand command)
        {
            var response = await mediator.Send(command);
            return response.Success ? Ok(response) : BadRequest(response);

        }
    }   
}
