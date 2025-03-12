
using Microsoft.AspNetCore.Builder;

namespace E_Commerce.Application.DTO.Cart
{
    public class CreateCheckoutHistory
    {
        public required string TapId { get; set; }
		public Guid ProductId { get; set; }
		public Guid ProductItemId { get; set; }
		public Guid ProductVariationId { get; set; }
		public int Quantity { get; set; } = 0;
        public DateTime DateTime { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Intiated";
        public decimal TotalPrice { get; set; } = default!;
    }
}
