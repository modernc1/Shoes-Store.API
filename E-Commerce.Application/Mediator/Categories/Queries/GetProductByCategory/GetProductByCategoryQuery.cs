using E_Commerce.Application.DTO.Product;
using E_Commerce.Domain.Models;
using MediatR;


namespace E_Commerce.Application.Mediator.Categories.Queries.GetProductByCategory
{
    public class GetProductByCategoryQuery : IRequest<IEnumerable<GetProduct>>
    {
        public Guid CategoryId { get; set; }
    }
}
