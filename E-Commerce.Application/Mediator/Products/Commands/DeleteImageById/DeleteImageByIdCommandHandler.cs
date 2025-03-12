using E_Commerce.Application.DTO;
using E_Commerce.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Mediator.Products.Commands.DeleteImageById
{
	internal class DeleteImageByIdCommandHandler(IProductRepository productRepository) : IRequestHandler<DeleteImageByIdCommand, ServerResponse>
	{
		public async Task<ServerResponse> Handle(DeleteImageByIdCommand request, CancellationToken cancellationToken)
		{
			//var result = await productRepository.DeleteImageById(request.Id);
			if (0 >= 1)
				return new ServerResponse() { Success = true, Message = "Image deleted successfully" };
			else
				return new ServerResponse() { Success = false, Message = "Failed to delete image" };
		}
	}
}
