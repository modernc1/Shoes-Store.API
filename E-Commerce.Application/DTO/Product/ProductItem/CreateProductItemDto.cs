using E_Commerce.Application.DTO.Product.ProductItem.ProductVariation;
using E_Commerce.Domain.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Application.DTO.Product.ProductItem
{
	public class CreateProductItemDto
	{
		public Guid ColorId { get; set; } = default!;
		public decimal OriginalPrice { get; set; } = default!;
		public decimal SalePrice { get; set; } = default!;
		public ICollection<IFormFile> Images { get; set; } = [];
		public string? ProductCode { get; set; } = default!;
		[MinLength(1)]
		public ICollection<CreateProductVariation> ProductVariations { get; set; } = [];

	}
}
