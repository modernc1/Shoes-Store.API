using E_Commerce.Domain.Models.Cart;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace E_Commerce.Domain.Models.Identity
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string FullName { get; set; } = default!;

        public List<Order> Orders { get; set; } = default!;

    }
}
