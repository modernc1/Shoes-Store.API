using E_Commerce.Application.DTO.Cart;
using MediatR;


namespace E_Commerce.Application.Mediator.Cart.Queries.GetCheckoutDetails
{
	public class GetCheckoutDetailsQuery : IRequest<List<GetCheckoutHistory>>
	{
		public required string charge_id { get; set; }
	}
}
