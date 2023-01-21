using Shoap.Models.Dtos;

namespace Shoap.Services.Contracts;

public interface ICartItemService
{
    Task<CartItemDto> GetCartItem(int productId, int userId);
    Task<IEnumerable<CartItemDto>> GetCartItems();
    Task<IEnumerable<CartItemDto>> GetUserCartItems(int userId);
    Task InsertCartItem(int productId, int userId);
    Task DeleteCartItem(CartItemDto cartItemDto);
}
