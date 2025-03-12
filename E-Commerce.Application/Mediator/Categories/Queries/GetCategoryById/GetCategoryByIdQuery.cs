using E_Commerce.Application.DTO.Category;
using MediatR;

namespace E_Commerce.Application.Mediator.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQuery : IRequest<GetCategory>
{
    public Guid Id { get; set; }
}
