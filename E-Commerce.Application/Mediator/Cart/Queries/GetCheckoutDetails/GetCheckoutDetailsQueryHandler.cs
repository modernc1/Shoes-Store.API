using AutoMapper;
using E_Commerce.Application.DTO.Cart;
using E_Commerce.Domain.Interfaces.Repositories;
using E_Commerce.Domain.Interfaces.Repositories.Cart;
using E_Commerce.Domain.Models.Cart;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Mediator.Cart.Queries.GetCheckoutDetails
{
	internal class GetCheckoutDetailsQueryHandler(ICartRepository cartRepository,
		IMapper mapper) : IRequestHandler<GetCheckoutDetailsQuery, List<GetCheckoutHistory>>
	{
		public async Task<List<GetCheckoutHistory>> Handle(GetCheckoutDetailsQuery request, CancellationToken cancellationToken)
		{
			var checkoutFromDb = await cartRepository.GetCheckoutHistoryByIdAsync(request.charge_id);
			if (checkoutFromDb == null)
			{
				return new List<GetCheckoutHistory>();
			}

			var response = new List<GetCheckoutHistory>();
			foreach (var item in checkoutFromDb)
			{
				var ProductCart = new ProductCartDTO
				{
					Id = item.Product.Id,
					Name = item.Product.Name,
					ProductItem = item.Product.ProductItems.Select(pi => new ProductItemCartDTO
					{
						Id = pi.Id,
						OriginalPrice = pi.OriginalPrice,
						SalePrice = pi.SalePrice,
						ProductVariation = pi.ProductVariations.Select(pv => new ProductVariationCartDTO
						{
							Id = pv.Id,
							Quantity = item.Quantity,
						}).FirstOrDefault(pv => pv.Id == item.ProductVariationId)!
					}).Where(pi => pi.Id == item.ProductItemId).FirstOrDefault()!
				};
				var checkout = new GetCheckoutHistory()
				{
					TapId = item.TapId,
					DateTime = item.DateTime,
					ProductId = item.ProductId,
					ProductItemId = item.ProductItemId,
					ProductVariationId = item.ProductVariationId,
					Product = ProductCart,
					Quantity = item.Quantity,
					Status = item.Status,
				};

				response.Add(checkout);
			}

			return response;
			
		}
	}
}
