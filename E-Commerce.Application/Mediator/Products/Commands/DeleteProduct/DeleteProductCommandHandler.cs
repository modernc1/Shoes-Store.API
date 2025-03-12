using AutoMapper;
using E_Commerce.Application.DTO;
using E_Commerce.Domain.Interfaces.Repositories;
using E_Commerce.Domain.Models;
using MediatR;

namespace E_Commerce.Application.Mediator.Products.Commands.DeleteProduct
{
    internal class DeleteProductCommandHandler(IProductRepository productService) : IRequestHandler<DeleteProductCommand, ServerResponse>
    {
        public async Task<ServerResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {

            int result = await productService.DeleteAsync(request.Id);

            if (result == 0)
            {
                return new ServerResponse(false, "Product Not Found");
            }

            return result > 0 ? new ServerResponse(true, "Product Deleted Successfully") :
                new ServerResponse(false, "Product Failed to be Deleted");
        }
    }
}
