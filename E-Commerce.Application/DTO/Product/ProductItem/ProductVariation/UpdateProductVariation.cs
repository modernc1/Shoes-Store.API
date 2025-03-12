using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.DTO.Product.ProductItem.ProductVariation
{
	public class UpdateProductVariation
	{	public Guid? id { get; set; }
		public Guid? ProductItemId { get; set; }
		public Guid SizeOptionId { get; set; }
		public int QuantityInStock { get; set; } = 0;
	}
}
