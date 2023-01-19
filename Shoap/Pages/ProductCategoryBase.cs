using Microsoft.AspNetCore.Components;
using Shoap.Models.Dtos;
using Shoap.Services.Contracts;

namespace Shoap.Pages;

public class ProductCategoryBase : ComponentBase
{
    [Parameter]
    public int CategoryId { get; set; }
    [Inject]
    public IProductService ProductService { get; set; }
    public string? CategoryName { get; set; }
    public IEnumerable<ProductDto> Products { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        try
        {
            Products = await ProductService.GetProductsInCategory(CategoryId);
            CategoryName = Products?.FirstOrDefault(product => product.CategoryId == CategoryId).CategoryName;
        }
        catch
        {
            throw;
        }
    }
}
