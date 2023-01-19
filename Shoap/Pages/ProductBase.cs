using Microsoft.AspNetCore.Components;
using Shoap.Models.Dtos;
using Shoap.Services.Contracts;

namespace Shoap.Pages;

public class ProductBase : ComponentBase
{
    [Parameter]
    public int Id { get; set; }
    [Inject]
    public IProductService ProductService { get; set; }
    public ProductDto? Product { get; set; }
    protected override async Task OnParametersSetAsync()
    {
        try 
        {
            Product = await ProductService.GetProduct(Id);
        }
        catch
        {
            throw;
        }
    }

    public void AddToCart()
    {

    }
}
