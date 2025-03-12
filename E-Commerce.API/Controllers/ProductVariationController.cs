using E_Commerce.Domain.Interfaces.Repositories;
using E_Commerce.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductVariationController(IGeneric<Color> colorRepository,
		IGeneric<SizeOption> sizeOprionRepository) : ControllerBase
	{
		[HttpGet("colors")]
		public async Task<IActionResult> GetColors()
		{
			var colors = await colorRepository.GetAllAsync();
			return Ok(colors);
		}

		[HttpGet("sizeOptions")]
		public async Task<IActionResult> GetSizeOptions()
		{
			var sizeOptions = await sizeOprionRepository.GetAllAsync();
			
			return Ok(sizeOptions.OrderBy(c => c.SortOrder));
		}

	}
}
