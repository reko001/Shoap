using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shoap.Services.Contracts;

namespace Shoap.Pages;

public class SignUpBase : ComponentBase
{
    [Inject]
    public IUserService UserService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    [Inject]
    public IJSRuntime JSRuntime { get; set; }
    public SignUpModel SignUpModel { get; set; } = new();

    public async Task SignUp()
    {
        if (await UserService.GetUser(SignUpModel!.Login) != null)
        {
            SignUpModel.ErrorMessage = "User with such login already exists.\nPlease try different login.";
            return;
        }
        await UserService.InsertUser(SignUpModel!.Login, SignUpModel!.Password);
        JSRuntime.InvokeVoidAsync("alert", "User has been added");
        NavigationManager.NavigateTo("/");
    }
}
