using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shoap.Models.Dtos;
using Shoap.Services.Contracts;

namespace Shoap.Pages;

public class CartBase : ComponentBase
{
    [Inject]
    public IContextService ContextService { get; set; }
    [Inject]
    public ICartItemService CartItemService { get; set; }
    [Inject]
    public IProductService ProductService { get; set; }
    [Inject]
    public IUserService UserService { get; set; }
    [Inject]
    public IJSRuntime JSRuntime { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    public Dictionary<CartItemDto, int> CartItems { get; set; }
    public decimal TotalCost;
    protected override async Task OnInitializedAsync()
    {
        if(ContextService.User == null)
        {
            return;
        }
        var cartItems = await CartItemService.GetUserCartItems(ContextService.User.Id);
        CartItems = cartItems.ToDictionary(item => item, item => 1);
        TotalCost = CartItems.Sum(item => item.Key.Price);
    }

    public void AddItem(CartItemDto cartItem)
    {
        CartItems[cartItem]++;
        TotalCost += cartItem.Price;
        StateHasChanged();
    }

    public void RemoveItem(CartItemDto cartItem)
    {
        CartItems[cartItem]--;
        TotalCost -= cartItem.Price;
        if (CartItems[cartItem] == 0)
        {
            CartItems.Remove(cartItem);
            CartItemService.DeleteCartItem(cartItem);
        }
        StateHasChanged();
    }

    public void Buy()
    {
        if(ContextService.User.Money < TotalCost)
        {
            JSRuntime.InvokeVoidAsync("alert", "You don't have enough money to buy those items.");
            return;
        }
        ContextService.User.Money -= TotalCost;
        foreach(var cartItem in CartItems)
        {
            CartItemService.DeleteCartItem(cartItem.Key);
        }
        CartItems.Clear();
        TotalCost = 0;
        UserService.UpdateMoney(ContextService.User);
        NavigationManager.NavigateTo("/");
    }
}
