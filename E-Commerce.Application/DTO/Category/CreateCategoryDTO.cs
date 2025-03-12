

using Microsoft.AspNetCore.Http;

namespace E_Commerce.Application.DTO.Category
{
    public class CreateCategoryDTO : CategoryBase
    {
        public Guid GenderId { get; set; }
        public IFormFile Image { get; set; } = default!;
    }
}
