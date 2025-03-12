using E_Commerce.Domain.Interfaces.Repositories;
using E_Commerce.Domain.Models;
using E_Commerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Implementations.Repositories
{
	internal class ProductItemRepository : GenericRepository<ProductItem>, IProductItemRepository
    {
        private AppDbContext context;
        public ProductItemRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }


    }
}
