

using E_Commerce.Domain.Models;

namespace E_Commerce.Application.DTO.Product.ProductItem.ProductVariation
{
	public class GetProductVariation
	{
		public Guid Id { get; set; }
		public SizeOption SizeOption { get; set; } = default!;
		public int QuantityInStock { get; set; } = 0;
	}
}
