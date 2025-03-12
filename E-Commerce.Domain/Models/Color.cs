using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Models
{
	public class Color
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = default!;
		public string HexCode { get; set; } = default!;
		[JsonIgnore]
		public ICollection<ProductItem>? ProductItems { get; set; } = [];
	}
}
