namespace E_Commerce.Application.DTO.Product.ProductItem.ProductVariation;

public class GetSizeOption
{
	public Guid Id { get; set; }
	public string Name { get; set; } = default!;
	public int SortOrder { get; set; } = default!;
}
