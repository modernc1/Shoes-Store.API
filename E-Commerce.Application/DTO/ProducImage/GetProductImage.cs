namespace E_Commerce.Application.DTO.ProducImage;

public class GetProductImage
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;

}
