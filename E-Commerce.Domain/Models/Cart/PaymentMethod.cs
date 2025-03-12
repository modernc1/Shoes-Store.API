
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Domain.Models.Cart;

public class PaymentMethod
{
    [Key]
    public string Id { get; set; } = default!;
    [Required]
    public string Name { get; set; } = default!;

}
