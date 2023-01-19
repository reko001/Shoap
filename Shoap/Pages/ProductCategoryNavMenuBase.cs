using Microsoft.AspNetCore.Components;
using Shoap.Models.Dtos;
using Shoap.Services.Contracts;

namespace Shoap.Pages;

public class ProductCategoryNavMenuBase : ComponentBase
{
    [Inject]
    public IProductService ProductService { get; set; }
    public IEnumerable<ProductCategoryDto> Categories { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            Categories = await ProductService.GetCategories();
        }
        catch
        {
            throw;
        }
    }
}
