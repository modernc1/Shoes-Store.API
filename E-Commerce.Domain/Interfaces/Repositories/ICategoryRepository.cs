using E_Commerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository : IGeneric<Category>
    {
        Task<IEnumerable<ProductGender>> GetGenders(bool loaded);
		Task<IEnumerable<Product>> GetProductsByCategory(Guid categoryId);
    }
}
