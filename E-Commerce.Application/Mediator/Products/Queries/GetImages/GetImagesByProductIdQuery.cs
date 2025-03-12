using E_Commerce.Application.DTO.ProducImage;
using MediatR;

namespace E_Commerce.Application.Mediator.Products.Queries.GetImages
{
	public class GetImagesByProductIdQuery : IRequest<IEnumerable<GetProductImage>>
	{
		public Guid Id { get; set; }
	}
}
