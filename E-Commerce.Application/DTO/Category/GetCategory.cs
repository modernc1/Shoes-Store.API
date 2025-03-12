

using E_Commerce.Application.DTO.Product;
using System.Text.Json.Serialization;

namespace E_Commerce.Application.DTO.Category
{
	public class GetCategory : CategoryBase
    {
        public Guid Id { get; set; }
        [JsonIgnore]
        public ICollection<GetProduct> Products { get; set; } = [];
        public Guid GenderId { get; set; }
        public string ImageUrl { get; set; } = default!;
    }
}
