using AutoMapper;
using E_Commerce.Application.DTO.ProducImage;
using E_Commerce.Domain.Interfaces.Repositories;
using E_Commerce.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Mediator.Products.Queries.GetImages
{
	internal class GetImagesByProductIdQueryHandler(IProductRepository productRepository, IMapper mapper): IRequestHandler<GetImagesByProductIdQuery, IEnumerable<GetProductImage>>
	{
		public async Task<IEnumerable<GetProductImage>> Handle(GetImagesByProductIdQuery request, CancellationToken cancellationToken)
		{
			//var productImages = await productRepository.GetProductImages(request.Id);
			//if (productImages == null)
			//	return [];

			//var mappedResponse = mapper.Map<IEnumerable<GetProductImage>>(productImages);

			return new List<GetProductImage>(); //mappedResponse;
		}
	}
}
