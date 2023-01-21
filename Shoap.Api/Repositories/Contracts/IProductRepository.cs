using Shoap.Api.Entities;

namespace Shoap.Api.Repositories.Contracts;

public interface IProductRepository
{
    Task<IEnumerable<Product>?> GetProducts();
    Task<IEnumerable<ProductCategory>?> GetCategories();
    Task<Product?> GetProduct(int id);
}
