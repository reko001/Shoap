using Shoap.Models.Dtos;
using Shoap.Services.Contracts;
using System.Net.Http.Json;

namespace Shoap.Services;

public class CartItemService : ICartItemService
{
    private readonly HttpClient _httpClient;
    public CartItemService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CartItemDto> GetCartItem(int productId, int userId)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<CartItemDto>($"api/CartItem/{productId}_{userId}");
        }
        catch
        {
            throw;
        }
    }

    public async Task<IEnumerable<CartItemDto>> GetCartItems()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CartItemDto>>("api/CartItem");
        }
        catch
        {
            throw;
        }
    }

    public async Task InsertCartItem(int productId, int userId)
    {
        try
        {
            CartItemDto cartItemDto = new() { ProductId = productId, UserId = userId };
            await _httpClient.PostAsJsonAsync("api/CartItem", cartItemDto);
        }
        catch
        {
            throw;
        }
    }
}
