using Microsoft.AspNetCore.Components;
using MyShop.App.Components.Alerts.enums;
using MyShop.App.Components.Alerts.Services;
using MyShop.App.Handlers;
using MyShop.Core.Requests.Identity;

namespace MyShop.App.Pages.Identity;

public partial class Login : ComponentBase
{
    public LoginRequest InputModel { get; set; } = new();

    [Inject] public AuthHandler AuthHandler { get; set; } = null!;
    [Inject] public NavigationManager Navigation { get; set; } = null!;
    [Inject] public AlertService Alert { get; set; } = null!;

    protected bool IsLoading { get; set; }
    

    private async Task OnSubmitAsync()
    {
        try
        {
            IsLoading = true;

            var response = await AuthHandler.Login(InputModel);

            if (!response)
            {
                Alert.ShowAlert(
                    "Erro ao realizar login",
                    AlertType.Danger);

                return;
            }

            Navigation.NavigateTo("/", forceLoad: true);
        }
        catch (Exception ex)
        {
            Alert.ShowAlert(
                "Erro inesperado ao autenticar.",
                AlertType.Danger);

            Console.WriteLine(ex);
        }
        finally
        {
            IsLoading = false;
        }
    }
}