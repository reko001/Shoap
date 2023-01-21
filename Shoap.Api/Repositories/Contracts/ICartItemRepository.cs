using Shoap.Api.Entities;

namespace Shoap.Api.Repositories.Contracts;

public interface ICartItemRepository
{
    Task<CartItem?> GetCartItem(int productId, int userId);
    Task<IEnumerable<CartItem>> GetCartItems();
    Task<IEnumerable<CartItem>> GetUserCartItems(int userId);
    Task InsertCartItem(CartItem cartItem);
    Task DeleteCartItem(int productId, int userId);
}
