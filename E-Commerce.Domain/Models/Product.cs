

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace E_Commerce.Domain.Models;

public class Product
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    [JsonIgnore]
    public Category? Category { get; set; }
    public Guid CategoryId { get; set; }
    public string Materials { get; set; } = default!;
    public string MainImageUrl { get; set; } = default!;
    public ICollection<ProductItem> ProductItems { get; set; } = [];

}
