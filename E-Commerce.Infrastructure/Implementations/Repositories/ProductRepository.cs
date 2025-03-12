using E_Commerce.Domain.Interfaces.Repositories;
using E_Commerce.Domain.Models;
using E_Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.Linq.Expressions;

namespace E_Commerce.Infrastructure.Implementations.Repositories
{
    internal class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly AppDbContext context;

        public ProductRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

		public async Task<(IEnumerable<Product>, int)> GetAllAsync(
			int pageSize = 10, int pageIndex = 1,
			string? includeProperties = null,
			string? filter = null, string? sortBy = "name",
			string? sortDir = "asc", List<Guid>? Genders = null,
			List<Guid>? Categories = null, List<Guid>? Sizes = null,
			List<Guid>? Colors = null)
		{
			IQueryable<Product> query = context.Products.AsNoTracking();

			if(!string.IsNullOrEmpty(includeProperties))
			{
				foreach(var property in includeProperties.Split(',', StringSplitOptions.TrimEntries))
				{
					//productVariations is auto included in appdbcontext;
					query = query.Include(property);
				}
			}
			//to prevent delay
			query = query.AsSplitQuery();

			if(!string.IsNullOrEmpty(filter))
			{
				query = query.Where(p => p.Name.Contains(filter));
			}

			if(Genders != null && Genders.Any())
			{
				query = query.Where(p => Genders.Contains(p.Category!.GenderId));
			}

			if (Categories != null && Categories.Any())
			{
				query = query.Where(p => Categories.Contains(p.CategoryId));
			}

			if (Sizes != null && Sizes.Any())
			{
				query = query.Where(p => p.ProductItems.Any(pi => pi.ProductVariations.Any(pv => Sizes.Contains(pv.SizeOptionId))));
			}

			if (Colors != null && Colors.Any())
			{
				query = query.Where(p => p.ProductItems.Any(pi => Colors.Contains(pi.ColorId)));
			}

			if (!string.IsNullOrEmpty(sortBy))
			{
				query = _ApplySorting<Product>(query, sortBy, sortDir?.ToLower() == "asc");
			}

			int totalCount = query.Count();
			query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

			return (await query.ToListAsync(), totalCount);
		}

		public override async Task<Product?> GetByIdAsync(Guid id)
		{
			var product = await context.Products
				.AsNoTracking()
				.Include(p => p.Category)
				.Include(p => p.ProductItems)
				.FirstOrDefaultAsync(p => p.Id == id);

			if (product == null)
				return null;

			return product;
		}

		public async Task<int> GetProductsCount(string? filter = null)
		{
			if(!string.IsNullOrEmpty(filter))
			{
				return await context.Products.Where(p => p.Name.Contains(filter)).CountAsync();
			}
			return await context.Products.CountAsync();
		}

		private IQueryable<T> _ApplySorting<T>(IQueryable<T> query, string sortBy, bool ascending)
		{
			var parameter = Expression.Parameter(typeof(T), "x"); // parameter in (x => x. ...);
			var property = Expression.PropertyOrField(parameter, sortBy); // like property (DateCreated) in this ex (x => x.DateCreated)
			var lambda = Expression.Lambda(property, parameter); // the actual lambda (x => x.Property)

			string methodName = ascending ? "OrderBy" : "OrderByDescending"; // the method name that we want to put lambda in it

			return query.Provider.CreateQuery<T>(
				Expression.Call(
					typeof(Queryable),
					methodName,
					new Type[] { typeof(T), property.Type },
					query.Expression,
					Expression.Quote(lambda)
				)
			);
		}

	}
}
