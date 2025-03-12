
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace E_Commerce.Domain.Models
{
    [Index(nameof(ProductItemId), IsUnique = false)]
    public class ProductImages
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(ProductItem))]
        public Guid ProductItemId { get; set; } = default!;
        [JsonIgnore]
        public ProductItem ProductItem { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
    }
}
