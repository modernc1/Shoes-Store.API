using E_Commerce.Application.DTO.Product.ProductItem.ProductVariation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.DTO.Product.ProductItem
{
	public class UpdateProductItemDto
	{
		public Guid? Id { get; set; }
		public Guid? ProductId { get; set; }
		public Guid ColorId { get; set; } = default!;
		public decimal OriginalPrice { get; set; } = default!;
		public decimal SalePrice { get; set; } = default!;
		public ICollection<IFormFile> Images { get; set; } = [];
		public string? ProductCode { get; set; } = default!;
		[MinLength(1)]
		public ICollection<CreateProductVariation> ProductVariations { get; set; } = [];
	}
}
