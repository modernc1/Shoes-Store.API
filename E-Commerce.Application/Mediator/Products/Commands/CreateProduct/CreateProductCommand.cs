using E_Commerce.Application.DTO;
using E_Commerce.Application.DTO.Product;
using MediatR;

namespace E_Commerce.Application.Mediator.Products.Commands.CreateProduct;

public class CreateProductCommand() : CreateProductDto, IRequest<ServerResponse>
{

}
