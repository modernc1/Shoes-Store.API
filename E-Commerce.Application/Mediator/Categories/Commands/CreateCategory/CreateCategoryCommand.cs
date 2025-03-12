using E_Commerce.Application.DTO;
using E_Commerce.Application.DTO.Category;
using MediatR;

namespace E_Commerce.Application.Mediator.Categories.Commands.CreateCategory;

public class CreateCategoryCommand : CreateCategoryDTO, IRequest<ServerResponse>
{
}
