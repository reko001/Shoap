using Microsoft.EntityFrameworkCore;
using Shoap.Api.Data;
using Shoap.Api.Entities;
using Shoap.Api.Repositories.Contracts;

namespace Shoap.Api.Repositories;

public class CartItemRepository : ICartItemRepository
{
    private readonly ShoapDbContext _context;
    public CartItemRepository(ShoapDbContext context)
    {
        _context = context;
    }

    public async Task<CartItem?> GetCartItem(int productId, int userId)
    {
        return await _context.CartItems.FindAsync(productId, userId);
    }

    public async Task<IEnumerable<CartItem>> GetCartItems()
    {
        return await _context.CartItems.ToListAsync();
    }

    public async Task InsertCartItem(CartItem cartItem)
    {
        await _context.CartItems.AddAsync(cartItem);
        await _context.SaveChangesAsync();
    }
}
