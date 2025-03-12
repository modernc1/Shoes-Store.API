using AutoMapper;
using E_Commerce.Application.DTO;
using E_Commerce.Application.DTO.Cart;
using E_Commerce.Application.Interfaces.Logging;
using E_Commerce.Application.Interfaces.Stripe;
using E_Commerce.Domain.Interfaces.Authentication;
using E_Commerce.Domain.Interfaces.Repositories;
using E_Commerce.Domain.Interfaces.Repositories.Cart;
using E_Commerce.Domain.Models;
using E_Commerce.Domain.Models.Cart;
using E_Commerce.Domain.Models.TapModels;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace E_Commerce.Application.Mediator.Cart.Commands.CreateCheckout
{
    internal class CreateCheckoutCommandHandler(IProductRepository productRepository, 
        IMapper mapper,
        ICartRepository cartRepository,
        IStripePaymentService stripePaymentService,
        IPaymentMethodRepository paymentMethodRepository,
        IUserManagement userManagement,
        IAppLogger<CreateCheckoutCommandHandler> logger) : IRequestHandler<CreateCheckoutCommand, TapCreateChargeResponse?>
    {
        public async Task<TapCreateChargeResponse?> Handle(CreateCheckoutCommand request, CancellationToken cancellationToken)
        {
            var (products, totalAmount) = await GetTotalAmount(request.CartItems);
            if (!products.Any() || totalAmount <= 0) return null;

            string paymentMethod = (await paymentMethodRepository.GetAllPaymentMethodsAsync()).FirstOrDefault(p => p.Name == request.PaymentMethod)!.Name;
            if (paymentMethod == null) return null;

            var paymentResponse = await stripePaymentService.PayTapAsync(totalAmount, products, paymentMethod);

            var isParsed = true; //Guid.TryParse(userManagement.GetCurrentUserId(), out Guid currUserId);
            if (paymentMethod != null && isParsed)
            {
                var checkoutHistory = new List<CreateCheckoutHistory>();

                foreach (var item in request.CartItems)
                {
                    checkoutHistory.Add(new CreateCheckoutHistory
                    {
                        TapId = paymentResponse!.id,
                        ProductId = item.ProductId,
                        ProductItemId = item.ProductItemId,
                        ProductVariationId = item.ProductVariationId,
                        Quantity = item.Quantity,
                        DateTime = DateTime.Now,
                        Status = paymentResponse.status,
                    });
                }
                var chekoutHs = mapper.Map<IEnumerable<CheckoutHistory>>(checkoutHistory);

                var order = new Domain.Models.Cart.Order()
                {
                    CreatedAt = DateTime.Now,
                    CheckoutHistories = chekoutHs.ToList(),
                    OrderStatus = "InProcess",
                    ShippingAddress = new Address
                    {
                        state = request.State,
                        street = request.Street,
                        city = request.City,
                        PhoneNumber = request.PhoneNumber
                    },
                    PaymentStatus = "Pending",
                    TotalAmount = totalAmount,
                    UserId = "e336e45d-d327-4711-9658-18abe67e53b0" //userManagement.GetCurrentUserId()!
				};

                int isSaved = await cartRepository.CreateOrder(order);
                if (isSaved <= 0) logger.LogError(new Exception(), "Failed To Save Checkout History");
            }

            return paymentResponse;
        }

        private async Task<(IEnumerable<ProductCartDTO>, decimal)> GetTotalAmount(IEnumerable<ProcessCart> cartItems)
        {
            if(!cartItems.Any()) return ([], 0);
            
            var productsFromDb = (await productRepository.GetAllAsync(includeProperties: "Category,ProductItems")).Item1;
            decimal totalAmount = 0;
            var selectedProducts = new List<ProductCartDTO>();
            foreach (var item in cartItems)
            {
                var product = productsFromDb.FirstOrDefault(p => p.Id == item.ProductId);

                var productItem = product!.ProductItems.Where(pi => pi.Id == item.ProductItemId)
                    .Select(pi => new ProductItemCartDTO
                    {
                        OriginalPrice = pi.OriginalPrice,
                        SalePrice = pi.SalePrice,
                        Id = pi.Id,
                        ProductVariation = pi.ProductVariations.Where(pv => pv.Id == item.ProductVariationId)
                        .Select(pv => new ProductVariationCartDTO
                        {
                            Id = pv.Id,
                            Quantity = item.Quantity
                        }).FirstOrDefault()!
                    }).FirstOrDefault();

                totalAmount += (productItem!.SalePrice * productItem.ProductVariation.Quantity);

                selectedProducts.Add(new ProductCartDTO
                {
                    Id = product.Id,
                    ProductItem = productItem!,
                    Name = product.Name,
                });

            }

            

            return (selectedProducts!, totalAmount);
        }
    }
}
