using Microsoft.AspNetCore.Components;
using Shoap.Services.Contracts;

namespace Shoap.Pages;

public class SignInBase : ComponentBase
{
    [Inject]
    public IUserService UserService { get; set; }
    [Inject]
    public IContextService ContextService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    public SignInModel SignInModel { get; set; } = new();

    public async Task SignIn()
    {
        if(!(await UserService.ExistsUser(SignInModel!.Login, SignInModel!.Password)))
        {
            SignInModel.ErrorMessage = "Incorrect login or password.\nPlease try again.";
            return;
        }
        var user = await UserService.GetUser(SignInModel!.Login);
        ContextService.UserId = user.Id;
        ContextService.UserName = user.Login;
        NavigationManager.NavigateTo("/");
    }
}
