using E_Commerce.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Mediator.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<ServerResponse>
    {
        public Guid Id { get; set; }
    }
}
