using Shoap.Models.Dtos;

namespace Shoap.Services.Contracts;

public interface ICartItemService
{
    Task<CartItemDto> GetCartItem(int productId, int userId);
    Task<IEnumerable<CartItemDto>> GetCartItems();
    Task InsertCartItem(int productId, int userId);
}
