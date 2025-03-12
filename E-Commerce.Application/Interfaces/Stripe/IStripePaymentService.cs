using E_Commerce.Application.DTO;
using E_Commerce.Application.DTO.Cart;
using E_Commerce.Domain.Models;
using E_Commerce.Domain.Models.TapModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Interfaces.Stripe
{
    public interface IStripePaymentService
    {
        Task<ServerResponse> PayAsync(decimal totalAmount, IEnumerable<ProductCartDTO> products, IEnumerable<ProcessCart> cartProducts, string paymentMethod);
		Task<TapCreateChargeResponse?> PayTapAsync(decimal totalAmount,
			IEnumerable<ProductCartDTO> cartProducts,
			string paymentMethods);
		Task<string> GetChargeStatusAsync(string charge_id);

	}
}
