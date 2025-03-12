using E_Commerce.Application.DTO.Category;
using E_Commerce.Application.DTO.Product.ProductItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.DTO.Cart
{
    public class ProductCartDTO
    {
		public Guid Id { get; set; }
		public string Name { get; set; } = default!;
		public ProductItemCartDTO ProductItem { get; set; } = default!;
	}
}
