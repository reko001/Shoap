using Microsoft.AspNetCore.Components;
using Shoap.Models.Dtos;
using Shoap.Services.Contracts;

namespace Shoap.Pages;

public class HomeBase : ComponentBase
{
    [Inject]
    public IProductService ProductService { get; set; }
    public IEnumerable<ProductDto>? Products { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Products = await ProductService.GetProducts();
    }
}
