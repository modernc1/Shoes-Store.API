using E_Commerce.Application.DTO.Category;
using MediatR;

namespace E_Commerce.Application.Mediator.Categories.Queries.GetAllCategories;
public class GetAllCategoriesQuery : IRequest<IEnumerable<GetCategory>>
{
}

