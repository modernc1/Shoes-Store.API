using AutoMapper;
using E_Commerce.Application.DTO;
using E_Commerce.Domain.Interfaces.Repositories;
using E_Commerce.Domain.Models;
using MediatR;

namespace E_Commerce.Application.Mediator.Categories.Commands.DeleteCategory;

internal class DeleteCategoryCommandHandler(ICategoryRepository categoryService) : IRequestHandler<DeleteCategoryCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {

        int result = await categoryService.DeleteAsync(request.Id);

        if (result == 0)
        {
            return new ServerResponse(false, "Category Not Found");
        }


        return result > 0? new ServerResponse(true, "Category Deleted Successfully") : 
            new ServerResponse(false, "Failed To Delete Category");
    }

}