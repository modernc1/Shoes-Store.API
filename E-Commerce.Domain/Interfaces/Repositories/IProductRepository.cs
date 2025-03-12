using E_Commerce.Domain.Models;

namespace E_Commerce.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IGeneric<Product>
    {
		//Task<List<ProductImages>> GetProductImages(Guid productId);
		//Task<int> DeleteImageById(Guid imgId);

		Task<(IEnumerable<Product>, int)> GetAllAsync(
			int pageSize = 10, int pageIndex = 1,
			string? includeProperties = null,
			string? filter = null, string? sortBy = "name",
			string? sortDir = "asc", List<Guid>? Genders = null, 
			List<Guid>? Categories = null, List<Guid>? Sizes = null,
			List<Guid>? Colors = null);

		Task<int> GetProductsCount(string? filter = null);
	}
}
