

namespace E_Commerce.Application.DTO.Cart
{
    public class ProcessCart
    {
        //we only need Product Id and quantity so client can't temp data
        public Guid ProductId { get; set; }
        public Guid ProductItemId { get; set; }
        public Guid ProductVariationId { get; set; }
        public int Quantity { get; set; } = 0;
    }
}
