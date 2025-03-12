using E_Commerce.Application.DTO;
using E_Commerce.Application.DTO.Cart;
using E_Commerce.Application.Interfaces.Stripe;
using E_Commerce.Domain.Static;
using Stripe.Checkout;
using RestSharp;
using System.Text.Json;
using E_Commerce.Domain.Models.TapModels;
using Newtonsoft.Json;
using E_Commerce.Domain.Interfaces.Repositories.Cart;
using Microsoft.Extensions.Options;
using E_Commerce.Application.Secrets;

namespace E_Commerce.Infrastructure.Services
{
    internal class StripePaymentService(ICartRepository cartRepository, TapConfiguration tapConfiguration) : IStripePaymentService
    {
        public async Task<ServerResponse> PayAsync(decimal totalAmount,
            IEnumerable<ProductCartDTO> cartProducts,
            IEnumerable<ProcessCart> cartItemsQuantity, 
            string paymentMethod)
        {
            try
            {
                //intiate stripe items
                var lineItems = new List<SessionLineItemOptions>();

                //loop throgh products
                foreach (var product in cartProducts)
                {
                    var pQuantity = cartItemsQuantity.FirstOrDefault(p => p.ProductId == product.Id)!.Quantity;

                    lineItems.Add(new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = StaticData.SiteCurrency,
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = product.Name,
                                Description = product.Name,
                            },
                            UnitAmount = (long)(product.ProductItem.SalePrice * 100)
                        },
                        Quantity = pQuantity
                    });
                }

                //generate process details
                var options = new SessionCreateOptions
                {
                    PaymentMethodTypes = [paymentMethod],
                    LineItems = lineItems,
                    Mode = "payment",
                    SuccessUrl = "https://localhost:7138/payment-success",
                    CancelUrl = "https://localhost:7138/payment-success"
                };
                var stripeClient = new Stripe.StripeClient("sk_test_51Pty4rJTqALmbis9X2x2zJNgsdwDcrFpcIsvgUIw7z4fCc6zI5iu1qiTT0aQAEgQP3ziaB0kaURdVOenjYTUnAiJ00RfwbAS3a");

                var service = new SessionService(stripeClient);
                Session session = await service.CreateAsync(options);

                return new ServerResponse(true, session.ToString());//session.Url);
            }
            catch(Exception ex)
            {
                return new ServerResponse(false, ex.Message);
            }
        }

        public async Task<TapCreateChargeResponse?> PayTapAsync(decimal totalAmount,
            IEnumerable<ProductCartDTO> cartProducts,
            string paymentMethods)
        {

			var options = new RestClientOptions("https://api.tap.company/v2/charges/");
			var client = new RestClient(options);
			var request = new RestRequest("");
			request.AddHeader("accept", "application/json");
			request.AddHeader("Authorization", $"Bearer {tapConfiguration.SecretKey}");

            var TapRequest = new TapCreateChargeRequest
            {
                amount = totalAmount,
                currency = StaticData.SiteCurrency.ToUpper(),
                customer = new Customer
                {
                    email = "email@email.com",
                    first_name = "First Name",
                    last_name = "Last Name"
                },
                customer_initiated = true,
                threeDSecure = true,

                source = new Source
                {
                    id = "src_all"
                },
                post = new Post
                {
                    url = $"{StaticData.FrontEndBaseUrl}/cart/checkoutResult"
				},
                redirect = new Redirect
                {
                    url = $"{StaticData.FrontEndBaseUrl}/cart/checkoutResult"
                }
            };

            string jsonBody = JsonConvert.SerializeObject(TapRequest);
            request.AddStringBody(jsonBody, DataFormat.Json);
            
            var response = await client.PostAsync(request);
            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<TapCreateChargeResponse>(response.Content!)!;
            }

            return null;

		}
    
        public async Task<string> GetChargeStatusAsync(string charge_id)
        {
			var options = new RestClientOptions($"https://api.tap.company/v2/charges/{charge_id}");
			var client = new RestClient(options);
			var request = new RestRequest("");
			request.AddHeader("accept", "application/json");
			request.AddHeader("Authorization", $"Bearer {tapConfiguration.SecretKey}");
			var response = await client.GetAsync(request);


			if (response.IsSuccessful)
			{
				var jsonResponse = JsonConvert.DeserializeObject<dynamic>(response.Content!);
                string status = jsonResponse!.status;
                await cartRepository.UpdateCheckoutHistory(charge_id, status);
				return status; // Returns the charge status
			}

            return "Error retriving payment status";
		}
	}


}
