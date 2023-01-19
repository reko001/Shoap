using Shoap.Models.Dtos;

namespace Shoap.Services.Contracts;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetProducts();
    Task<IEnumerable<ProductCategoryDto>> GetCategories();
    Task<IEnumerable<ProductDto>> GetProductsInCategory(int categoryId);
    Task<ProductDto> GetProduct(int id);
}
