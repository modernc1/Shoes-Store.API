using E_Commerce.Domain.Interfaces.Repositories;
using E_Commerce.Domain.Models;
using E_Commerce.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infrastructure.Implementations.Repositories
{
    internal class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;


        public CategoryRepository(AppDbContext context, IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor) : base(context)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;

        }

		public async Task<IEnumerable<ProductGender>> GetGenders(bool loaded)
		{
            if (loaded)
            {
				return await context.Genders.Include(c => c.Categories).ToListAsync();
			}
			return await context.Genders.ToListAsync();
		}

		public async Task<IEnumerable<Product>> GetProductsByCategory(Guid categoryId)
        {
            var result = await context.Products.Include(c => c.Category).Where(p => p.CategoryId == categoryId).AsNoTracking().ToListAsync();
            return result.Any()? result : [];
        }

		public override async Task<int> DeleteAsync(Guid id)
		{
            var category = context.Categories.FirstOrDefault(c => c.Id == id);
            if (category is null)
                return 0;
            var filePath = category.ImageUrl;
            context.Categories.Remove(category);
            if(await context.SaveChangesAsync() > 0)
            {
				DeleteFile(filePath);
                return 1;
            }

            return -1;
		}

        private bool DeleteFile(string filePath)
		{
            var index = filePath.IndexOf("Images/");
            var localPath = filePath.Substring(index);
            if (File.Exists(localPath))
			{
				File.Delete(localPath);
				return true;
			}
			return false;
		}
    }
}
