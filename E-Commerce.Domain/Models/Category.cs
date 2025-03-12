
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace E_Commerce.Domain.Models;

public class Category
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; } = default!;
    [JsonIgnore]
    public ICollection<Product> Products { get; set; } = [];
    public string ImageUrl { get; set; } = default!;
    public Guid GenderId { get; set; }
    [JsonIgnore]
    public ProductGender? Gender { get; set; } = default!;

}
