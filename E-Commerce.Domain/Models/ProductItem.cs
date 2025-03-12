using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Models
{
	public class ProductItem
	{
		public Guid Id { get; set; }
		[ForeignKey(nameof(Product))]
		public Guid ProductId { get; set; }
		public Product? Product { get; set; } = default!;
		[ForeignKey(nameof(Color))]
		public Guid ColorId { get; set; }
		public Color? Color { get; set; } = default!;
		[Column(TypeName = "decimal(18,2)")]
		public decimal OriginalPrice { get; set; } = default!;
		[Column(TypeName = "decimal(18,2)")]
		public decimal SalePrice { get; set; } = default!;
		public ICollection<ProductImages>? Images { get; set; } = [];
		public string? ProductCode { get; set; } = default!;
		public ICollection<ProductVariation> ProductVariations { get; set; } = [];
	}
}
