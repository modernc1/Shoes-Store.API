

using System.Text.Json.Serialization;

namespace E_Commerce.Domain.Models
{
    public class ProductVariation
    {
        public Guid Id { get; set; }
        public Guid ProductItemId {  get; set; }
        [JsonIgnore]
        public ProductItem? ProductItem { get; set; } = default!;
        public Guid SizeOptionId { get; set; }
        public SizeOption? SizeOption { get; set; } = default!;
        public int QuantityInStock { get; set; } = 0;
    }
}
