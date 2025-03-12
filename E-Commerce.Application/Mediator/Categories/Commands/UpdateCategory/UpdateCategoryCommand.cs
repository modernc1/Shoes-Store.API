using E_Commerce.Application.DTO;
using E_Commerce.Application.DTO.Category;
using E_Commerce.Application.DTO.Product;
using MediatR;

namespace E_Commerce.Application.Mediator.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommand : UpdateCategoryDTO, IRequest<ServerResponse>
{
    public Guid Id { get; set; }
}
