using E_Commerce.Application.DTO.Category;
using E_Commerce.Application.DTO.Product.ProductItem;
using System.Text.Json.Serialization;

namespace E_Commerce.Application.DTO.Product;

public class GetProduct
{
    public Guid Id { get; set; }
	public string Name { get; set; } = default!;
	public string Description { get; set; } = default!;
	public PCategory? Category { get; set; }
	public Guid CategoryId { get; set; }
	public string Materials { get; set; } = default!;
	public string MainImageUrl { get; set; } = default!;
	public IEnumerable<GetProductItem> ProductItems { get; set; } = [];

}