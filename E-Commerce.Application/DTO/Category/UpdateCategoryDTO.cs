

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Application.DTO.Category;

public class UpdateCategoryDTO : CategoryBase
{
	public Guid GenderId { get; set; }
	public IFormFile? Image { get; set; } = default!;
}
