using E_Commerce.Domain.Models.TapModels;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Domain.Models.Cart
{
	public class Address
	{
		public Guid Id { get; set; }
		public string city { get; set; } = default!;
		public string state { get; set; } = default!;
		public string street { get; set; } = default!;
		[Phone]
		public string PhoneNumber { get; set; } = default!;
		
		
	}
}
