using Microsoft.EntityFrameworkCore;
using Shoap.Api.Data;
using Shoap.Api.Entities;
using Shoap.Api.Repositories.Contracts;

namespace Shoap.Api.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ShoapDbContext _context;
    public ProductRepository(ShoapDbContext shoapDbContext)
    {
        _context = shoapDbContext;
    }
    public async Task<IEnumerable<ProductCategory>?> GetCategories()
    {
        return await _context.ProductCategories.ToListAsync();
    }

    public Task<ProductCategory?> GetCategory(int id)
    {
         throw new NotImplementedException();
    }

    public Task<Product?> GetItem(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Product>?> GetItems()
    {
        return await _context.Products.ToListAsync();
    }
}
