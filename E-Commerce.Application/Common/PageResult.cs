
namespace E_Commerce.Application.Common
{
	public class PageResult<T>(IEnumerable<T> Items, int TotalCount, int PageSize, int PageNumber)
	{
		public IEnumerable<T> Products { get; set; } = Items;
		public int TotalCount { get; set; } = TotalCount;
		public int TotalPageCount { get; set; } = (int)Math.Ceiling(TotalCount / (double)PageSize);
		public int CurrentPage { get; set; } = PageNumber;
		public int ItemFrom { get; set; } = PageSize * (PageNumber - 1) + 1;
		public int ItemTo { get; set; } = PageSize * PageNumber;
	}
}
