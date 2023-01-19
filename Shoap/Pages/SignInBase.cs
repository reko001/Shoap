using Microsoft.AspNetCore.Components;
using Shoap.Services.Contracts;

namespace Shoap.Pages;

public class SignInBase : ComponentBase
{
    [Inject]
    public IUserService UserService { get; set; }
    public SignInModel SignInModel { get; set; } = new();

    public void SignIn()
    {
        var user = UserService.GetUser(SignInModel.Login);
        if(user != null)
        {

        }
        if(user == null)
        {
            SignInModel.ErrorMessage = "Incorrect login or password.\nPlease try again.";
        }
    }
}
