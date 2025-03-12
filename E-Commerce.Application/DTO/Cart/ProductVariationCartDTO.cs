using E_Commerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.DTO.Cart
{
	public class ProductVariationCartDTO
	{
		public Guid Id { get; set; }
		public int Quantity { get; set; } = 0;
	}
}
