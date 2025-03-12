using E_Commerce.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Models.Cart
{
	public class Order
	{
		public Guid Id { get; set; }
		[ForeignKey(nameof(User))]
		[Required]
		public string UserId { get; set; } = default!; // Foreign key for Customer
		public AppUser User { get; set; } = default!;
		public decimal TotalAmount { get; set; }
		public string OrderStatus { get; set; } = "Pending";  // Default: Pending
		public string PaymentStatus { get; set; } = "Unpaid"; // Default: Unpaid
		[ForeignKey(nameof(ShippingAddress))]
		public Guid ShippingAddressId { get; set; }
		public Address ShippingAddress { get; set; } = default!;
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
		public List<CheckoutHistory> CheckoutHistories { get; set; } = [];
	
		//implement get orders by user
	}
}
