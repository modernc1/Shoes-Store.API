using AutoMapper;
using E_Commerce.Application.DTO.Category;
using E_Commerce.Application.DTO.Product;
using E_Commerce.Application.Exceptions;
using E_Commerce.Domain.Interfaces.Repositories;
using E_Commerce.Domain.Models;
using MediatR;


namespace E_Commerce.Application.Mediator.Categories.Queries.GetCategoryById;

internal class GetCategoryByIdQueryHandler(ICategoryRepository categoryService, IMapper mapper) : IRequestHandler<GetCategoryByIdQuery, GetCategory>
{
    public async Task<GetCategory> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await categoryService.GetByIdAsync(request.Id);
        if (category is null)
            throw new ItemNotFoundException("Product Not Found"); ;
        

        var mappedProduct = mapper.Map<GetCategory>(category);

        return mappedProduct;
    }
}
