using Shoap.Models.Dtos;
using Shoap.Services.Contracts;
using System.Net.Http.Json;

namespace Shoap.Services;

public class ProductService : IProductService
{
    private readonly HttpClient httpClient;

    public ProductService(HttpClient httpClient)
	{
        this.httpClient = httpClient;
    }

    public async Task<IEnumerable<ProductCategoryDto>> GetCategories()
    {
        try
        {
            var response = await httpClient.GetAsync("api/Product/GetCategories");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<ProductCategoryDto>();
                }
                return await response.Content.ReadFromJsonAsync<IEnumerable<ProductCategoryDto>>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Response code: {response.StatusCode}, message: {message}");
            }
        }
        catch
        {
            throw;
        }
    }

    public async Task<IEnumerable<ProductDto>> GetProducts()
    {
        try
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("api/Product");
        }
        catch
        {
            throw;
        }
    }

    public async Task<IEnumerable<ProductDto>> GetProductsInCategory(int categoryId)
    {
        try
        {
            return (await httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("api/Product")).Where(product => product.CategoryId == categoryId);
        }
        catch
        {
            throw;
        }
    }

    public async Task<ProductDto> GetProduct(int id)
    {
        try
        {
            return await httpClient.GetFromJsonAsync<ProductDto>($"api/Product/{id}");
        }
        catch
        {
            throw;
        }
    }
}
