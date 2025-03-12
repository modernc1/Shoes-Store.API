using E_Commerce.Application.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.DTO.Cart
{
	internal class GetCheckoutHistory
	{
		public required string TapId { get; set; }
		public Guid ProductId { get; set; }
		public ProductCartDTO Product { get; set; } = default!;
		public Guid ProductItemId { get; set; }
		public Guid ProductVariationId { get; set; }
		public int Quantity { get; set; } = 0;
		public Guid UserId { get; set; } = default!;
		public DateTime DateTime { get; set; } = DateTime.Now;
		public string Status { get; set; } = "Intiated";
	}
}
