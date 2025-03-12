using E_Commerce.Application.Interfaces.Stripe;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Mediator.Cart.Queries.GetChargeStatus
{
	internal class GetChargeStatusQueryHandler(IStripePaymentService paymentService) : IRequestHandler<GetChargeStatusQuery, string>
	{
		public async Task<string> Handle(GetChargeStatusQuery request, CancellationToken cancellationToken)
		{
			if(request.charge_id != null)
			{
				return await paymentService.GetChargeStatusAsync(request.charge_id);
			}
			return "Enter Valid Charge Id";
		}
	}
}
