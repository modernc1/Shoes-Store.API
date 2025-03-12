using AutoMapper;
using E_Commerce.Application.DTO.Cart;
using E_Commerce.Domain.Interfaces.Repositories.Cart;
using MediatR;

namespace E_Commerce.Application.Mediator.Cart.Queries.GetAllPaymentMethods;

internal class GetAllPaymentMethodsQueryHandler(IMapper mapper, IPaymentMethodRepository paymentMethodRepository) : IRequestHandler<GetAllPaymentMethodsQuery, IEnumerable<GetPaymentMethod>>
{
    public async Task<IEnumerable<GetPaymentMethod>> Handle(GetAllPaymentMethodsQuery request, CancellationToken cancellationToken)
    {
        var pMethods = await paymentMethodRepository.GetAllPaymentMethodsAsync();
        var result = mapper.Map<IEnumerable<GetPaymentMethod>>(pMethods);

        return result;
    }
}
