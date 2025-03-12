using E_Commerce.Infrastructure.Data;
using E_Commerce.Domain.Interfaces.Repositories.Cart;
using E_Commerce.Domain.Models.Cart;
using Microsoft.EntityFrameworkCore;


namespace E_Commerce.Infrastructure.Implementations.Repositories.Cart
{
    internal class PaymentMethodRepository(AppDbContext context) : IPaymentMethodRepository
    {
        public async Task<IEnumerable<PaymentMethod>> GetAllPaymentMethodsAsync()
        {
            return await context.PaymentMethods.AsNoTracking().ToListAsync();
        }
    }
}
