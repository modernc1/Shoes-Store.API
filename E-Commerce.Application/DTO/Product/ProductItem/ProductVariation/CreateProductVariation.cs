using E_Commerce.Domain.Models;

namespace E_Commerce.Application.DTO.Product.ProductItem.ProductVariation
{
	public class CreateProductVariation
	{
		public Guid SizeOptionId { get; set; }
		public int QuantityInStock { get; set; } = 0;
	}
}
