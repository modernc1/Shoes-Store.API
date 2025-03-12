using AutoMapper;
using E_Commerce.Application.DTO.Category;
using E_Commerce.Application.DTO.Product;
using E_Commerce.Domain.Interfaces.Repositories;
using E_Commerce.Domain.Models;
using MediatR;


namespace E_Commerce.Application.Mediator.Categories.Queries.GetAllCategories;

internal class GetAllCategoriesQueryHandler(ICategoryRepository categoryService, IMapper mapper) : IRequestHandler<GetAllCategoriesQuery, IEnumerable<GetCategory>>
{
    public async Task<IEnumerable<GetCategory>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categoriesList = await categoryService.GetAllAsync("Gender");

        if (categoriesList.Count() == 0) return [];

        var mappedList = mapper.Map<IEnumerable<GetCategory>>(categoriesList);

        return mappedList;
    }
}
