using Shoap.Models.Dtos;
using Shoap.Pages;
using Shoap.Services.Contracts;
using System.Net.Http.Json;
using System.Text.Json;

namespace Shoap.Services;

public class CartItemService : ICartItemService
{
    private readonly HttpClient _httpClient;
    public CartItemService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task DeleteCartItem(CartItemDto cartItemDto)
    {
        try
        {
            await _httpClient.DeleteAsync($"api/CartItem?productId={cartItemDto.ProductId}&userId={cartItemDto.UserId}");
        }
        catch
        {
            throw;
        }
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

    public async Task<IEnumerable<CartItemDto>> GetUserCartItems(int userId)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CartItemDto>>($"api/CartItem/{userId}");
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
            var product = await _httpClient.GetFromJsonAsync<ProductDto>($"api/Product/{productId}");
            CartItemDto cartItemDto = new() { ProductId = productId, UserId = userId, Name = product.Name, Price = product.Price };
            await _httpClient.PostAsJsonAsync("api/CartItem", cartItemDto);
        }
        catch
        {
            throw;
        }
    }
}
