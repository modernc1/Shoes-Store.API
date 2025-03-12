using E_Commerce.Application.DTO.Product.ProductItem.ProductVariation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.DTO.Cart
{
	public class ProductItemCartDTO
	{
		public Guid Id { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal OriginalPrice { get; set; } = default!;
		[Column(TypeName = "decimal(18,2)")]
		public decimal SalePrice { get; set; } = default!;
		public ProductVariationCartDTO ProductVariation { get; set; } = default!;
	}
}
