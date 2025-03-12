using AutoMapper;
using E_Commerce.Application.Common;
using E_Commerce.Application.DTO.Product;
using E_Commerce.Domain.Interfaces.Repositories;
using E_Commerce.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace E_Commerce.Application.Mediator.Products.Queries.GetAllProducts;

internal class GetAllProductsQueryHandler(IProductRepository productService, IMapper mapper) : IRequestHandler<GetAllProductsQuery, PageResult<GetProduct>>
{
    public async Task<PageResult<GetProduct>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {

        (var productsList,var totalCount) = await productService.GetAllAsync(request.PageSize, request.PageIndex, includeProperties: "Category,ProductItems",
            request.filter, request.SortBy, request.SortOrder, request.Genders, request.Categories, request.Sizes, request.Colors);

        if (totalCount == 0) return new PageResult<GetProduct>([], totalCount, request.PageSize, request.PageIndex);
        
        var mappedList = mapper.Map<IEnumerable<GetProduct>>(productsList);
        
        return new PageResult<GetProduct>(mappedList, totalCount, request.PageSize, request.PageIndex);
    }
}
