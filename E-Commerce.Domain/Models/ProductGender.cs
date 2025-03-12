
using System.Text.Json.Serialization;

namespace E_Commerce.Domain.Models
{
	public class ProductGender
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = default!;
		[JsonIgnore]
		public ICollection<Category>? Categories { get; set; } = default!;
	}
}
