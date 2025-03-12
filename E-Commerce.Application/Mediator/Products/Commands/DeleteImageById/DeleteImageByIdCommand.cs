using E_Commerce.Application.DTO;
using MediatR;

namespace E_Commerce.Application.Mediator.Products.Commands.DeleteImageById
{
	public class DeleteImageByIdCommand : IRequest<ServerResponse>
	{
		public Guid Id { get; set; }
	}
}
