using AutoMapper;
using E_Commerce.Application.DTO.Category;
using E_Commerce.Application.DTO.Product;
using E_Commerce.Domain.Interfaces.Repositories;
using E_Commerce.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Mediator.Categories.Queries.GetProductByCategory
{
    internal class GetProductByCategoryQueryHandler(ICategoryRepository categoryRepository,
        IMapper mapper) : IRequestHandler<GetProductByCategoryQuery, IEnumerable<GetProduct>>
    {
        public async Task<IEnumerable<GetProduct>> Handle(GetProductByCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await categoryRepository.GetProductsByCategory(request.CategoryId);
            if (!result.Any()) return [];
            
            var mappedResult = mapper.Map<IEnumerable<GetProduct>>(result);

            return mappedResult;
        }
    }
}
