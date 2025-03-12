using E_Commerce.Application.DTO.Cart;
using MediatR;

namespace E_Commerce.Application.Mediator.Cart.Queries.GetAllPaymentMethods
{
    public class GetAllPaymentMethodsQuery : IRequest<IEnumerable<GetPaymentMethod>>
    {
    }
}
