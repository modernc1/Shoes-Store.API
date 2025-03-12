using E_Commerce.Infrastructure.Data;
using E_Commerce.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infrastructure.Implementations.Repositories
{
    internal class GenericRepository<TEntity>(AppDbContext context) : IGeneric<TEntity> where TEntity : class
    {
        public async Task<int> AddAsync(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            return await context.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync(Guid id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity is null)
                return 0;
            context.Set<TEntity>().Remove(entity);
            return await context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(string? includeProperties = null)
        {
            var DbSet = context.Set<TEntity>();
            IQueryable<TEntity> query = DbSet;
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach(var inclprop in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
					query = query.Include(inclprop);
				}
                
            }
            var s = await query.ToListAsync();
            return s;
        }

        public virtual async Task<TEntity?> GetByIdAsync(Guid id)
        {
            //cann't use AsNoTracking With FindAsync in Generic so we handle it after the method
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity is null)
                return null;

            //in case it is not null detatch it from Tracking
            //in order ro not give Exception during Update
            context.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            return await context.SaveChangesAsync();
        }
    }
}
