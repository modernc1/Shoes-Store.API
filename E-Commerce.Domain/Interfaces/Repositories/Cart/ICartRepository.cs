using E_Commerce.Domain.Models.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Interfaces.Repositories.Cart
{
    public interface ICartRepository
    {
        Task<int> CreateOrder(Order order);
        Task<IEnumerable<CheckoutHistory>?> GetCheckoutHistoryByIdAsync(string chargeId);
        Task<int> UpdateCheckoutHistory(string chargeId, string status);
        Task<int> UpdateOrderSatatus(Guid orderId, string? orderStatus, string? paymentStatus);

	}
}
