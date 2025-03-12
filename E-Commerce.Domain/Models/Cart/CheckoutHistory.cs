using E_Commerce.Domain.Models.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Domain.Models.Cart
{
    public class CheckoutHistory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string TapId { get; set; } = default!;
		public Guid ProductId { get; set; }
		public Guid ProductItemId { get; set; }
		public Guid ProductVariationId { get; set; }
        public Product Product { get; set; } = default!;
        public int Quantity { get; set; } = 0;
        public decimal TotalPrice { get; set; } = default!;
        [ForeignKey(nameof(Order))]
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = default!;
        public DateTime DateTime { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Intiated";
    }
}
