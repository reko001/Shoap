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

    public async Task<Product?> GetProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            product.Visits++;
            _context.Products.Update(product);
            _context.SaveChanges();
        }
        return product;
    }

    public async Task<IEnumerable<Product>?> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }
}
