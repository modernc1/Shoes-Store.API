using E_Commerce.Domain.Interfaces.Repositories.Cart;
using E_Commerce.Domain.Models.Cart;
using E_Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infrastructure.Implementations.Repositories.Cart
{
    public class CartRepository(AppDbContext context) : ICartRepository
    {
        public async Task<int> CreateOrder(Order order)
        {
            await context.Orders.AddAsync(order);

            return await context.SaveChangesAsync();
        }
        
        public async Task<int> UpdateCheckoutHistory(string chargeId, string status)
        {
            var checkoutHistory = await context.CheckoutHistory.Where(c => c.TapId == chargeId).ToListAsync();
            var order = await context.Orders.FirstOrDefaultAsync(o => o.Id == checkoutHistory.First().OrderId);
            var result = 0;
            if(checkoutHistory != null) 
            {
                foreach(var item in checkoutHistory)
                {
                    item.Status = status;
                }
                context.CheckoutHistory.UpdateRange(checkoutHistory);
                if(order != null)
                {
					order.PaymentStatus = status;
                    context.Orders.Update(order);
				}
                result = await context.SaveChangesAsync();
            }
            return result;
		}

		public async Task<IEnumerable<CheckoutHistory>?> GetCheckoutHistoryByIdAsync(string chargeId)
        {
            var response = await context.CheckoutHistory.Include(c => c.Product).ThenInclude(p => p.ProductItems).Where(c => c.TapId == chargeId).ToListAsync();
            return response;
        }
        
        public async Task<int> UpdateOrderSatatus(Guid orderId, string? orderStatus, string? paymentStatus)
        {
            var order = context.Orders.FirstOrDefault(o => o.Id == orderId);
            if(order == null)
                return 0;
            if(orderStatus != null)
                order.OrderStatus = orderStatus;
            
            if(paymentStatus != null)
                order.PaymentStatus = paymentStatus;

            order.UpdatedAt = DateTime.Now;
            context.Orders.Update(order);
            return await context.SaveChangesAsync();
        }
    }
}
