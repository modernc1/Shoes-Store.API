

using E_Commerce.Application.Common;
using E_Commerce.Application.DTO.Product;
using MediatR;

namespace E_Commerce.Application.Mediator.Products.Queries.GetAllProducts;

public class GetAllProductsQuery : IRequest<PageResult<GetProduct>>
{
	public string? filter { get; set; } = default!;
	public List<Guid>? Genders { get; set; } = [];
	public List<Guid>? Categories { get; set; } = [];
	public List<Guid>? Colors { get; set; } = [];
	public List<Guid>? Sizes { get; set; } = [];
	public int PageSize { get; set; } = 5;
	public int PageIndex { get; set; } = 1;
	public string? SortBy { get; set; } = "name";
	public string? SortOrder { get; set; } = "asc";
	
}

