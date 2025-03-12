

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace E_Commerce.Domain.Models
{
	public class SizeOption
	{
		[Key]
		public Guid Id { get; set; }
		public string Name { get; set; } = default!;
		public int SortOrder {  get; set; }
		[JsonIgnore]
		public ICollection<ProductVariation> ProductVariations { get; set; } = [];
	}
}
