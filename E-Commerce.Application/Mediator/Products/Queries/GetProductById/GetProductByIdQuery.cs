
using E_Commerce.Application.DTO.Product;
using MediatR;

namespace E_Commerce.Application.Mediator.Products.Queries.GetProductById;

public class GetProductByIdQuery : IRequest<GetProduct>
{
    public Guid Id { get; set; }
}
