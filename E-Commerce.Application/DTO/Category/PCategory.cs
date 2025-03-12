namespace E_Commerce.Application.DTO.Category
{
	public class PCategory
	{
		public Guid Id { get; set; }
		public Guid GenderId { get; set; }
		public string Name { get; set; } = default!;
		public string ImageUrl { get; set; } = default!;
	}
}
