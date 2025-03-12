using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_Commerce.Application.DTO.Category
{
	public class GetGender
	{
		public Guid Id {  get; set; }
		public string Name { get; set; } = default!;
		public IEnumerable<GetCategory> Categories { get; set; } = [];
	}
}
