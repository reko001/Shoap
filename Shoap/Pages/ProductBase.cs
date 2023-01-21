using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shoap.Models.Dtos;
using Shoap.Services.Contracts;

namespace Shoap.Pages;

public class ProductBase : ComponentBase
{
    [Parameter]
    public int Id { get; set; }
    [Inject]
    public IProductService ProductService { get; set; }
    [Inject]
    public IContextService ContextService { get; set; }
    [Inject]
    public ICartItemService CartItemService { get; set; }
    [Inject]
    public IJSRuntime JSRuntime { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
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

    public async Task AddToCart()
    {
        var user = ContextService.User;
        if(user == null)
        {
            await JSRuntime.InvokeVoidAsync("alert", "You need to be logged in to add item to cart!");
            return;
        }
        await CartItemService.InsertCartItem(Product!.Id, user.Id);
        NavigationManager.NavigateTo("/");
        await JSRuntime.InvokeVoidAsync("alert", "Item has been added to the cart");
    }
}
