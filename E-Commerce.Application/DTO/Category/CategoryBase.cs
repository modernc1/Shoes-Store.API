

using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Application.DTO.Category
{
    public class CategoryBase
    {
        [Required]
        public string Name { get; set; } = default!;
    }
}
