using AutoMapper;
using E_Commerce.Application.DTO.ProducImage;
using E_Commerce.Application.DTO.Product;
using E_Commerce.Application.Exceptions;
using E_Commerce.Domain.Interfaces.Repositories;
using E_Commerce.Domain.Models;
using E_Commerce.Infrastructure.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;


namespace E_Commerce.Application.Mediator.Products.Queries.GetProductById;

internal class GetProductByIdQueryHandler(IProductRepository productService, IMapper mapper) : IRequestHandler<GetProductByIdQuery, GetProduct>
{
    public async Task<GetProduct> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await productService.GetByIdAsync(request.Id);
        if (product == null) return new GetProduct();
        var mappedProduct = mapper.Map<GetProduct>(product);

        return mappedProduct; //mappedProduct;
    }
}
