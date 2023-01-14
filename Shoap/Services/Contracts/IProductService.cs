using Shoap.Models.Dtos;

namespace Shoap.Services.Contracts;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetItems();
}
