using E_Commerce.Application.DTO;
using MediatR;


namespace E_Commerce.Application.Mediator.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommand : IRequest<ServerResponse>
{
    public Guid Id { get; set; }
}
