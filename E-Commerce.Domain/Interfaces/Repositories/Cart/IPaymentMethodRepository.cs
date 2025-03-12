using E_Commerce.Domain.Models.Cart;


namespace E_Commerce.Domain.Interfaces.Repositories.Cart;

public interface IPaymentMethodRepository
{
    public Task<IEnumerable<PaymentMethod>> GetAllPaymentMethodsAsync();
}
