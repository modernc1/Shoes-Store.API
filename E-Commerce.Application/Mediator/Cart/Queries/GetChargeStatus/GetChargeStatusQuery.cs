using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Mediator.Cart.Queries.GetChargeStatus
{
	public class GetChargeStatusQuery : IRequest<string>
	{
		public string charge_id { get; set; } = default!;
	}
}
