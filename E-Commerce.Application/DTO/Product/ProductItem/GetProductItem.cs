using E_Commerce.Application.DTO.ProducImage;
using E_Commerce.Application.DTO.Product.ProductItem.ProductVariation;
using E_Commerce.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Application.DTO.Product.ProductItem
{
	public class GetProductItem
	{
		public Guid Id { get; set; }
		public Guid ColorId { get; set; } = default!;
		[Column(TypeName = "decimal(18,2)")]
		public decimal OriginalPrice { get; set; } = default!;
		[Column(TypeName = "decimal(18,2)")]
		public decimal SalePrice { get; set; } = default!;
		public IEnumerable<string> ImagesUrl { get; set; } = [];
		public string? ProductCode { get; set; } = default!;
		public IEnumerable<GetProductVariation> ProductVariations { get; set; } = [];
	}
}
