using Microsoft.AspNetCore.Components;
using MyShop.App.Components.Alerts.enums;
using MyShop.App.Components.Alerts.Services;
using MyShop.Core.Handlers;
using MyShop.Core.Requests.Categories;

namespace MyShop.App.Pages.Categories;

public partial class Create : ComponentBase
{
    private string? message =  string.Empty;
    
    [Parameter] 
    public EditorCategoryRequest InputModel { get; set; } = new();

    [Inject] private NavigationManager _navigationManager { get; set; } = null!;


    [Inject] private ICategoryHandler _handler { get; set; } = null!;
    
    [Inject] 
    protected AlertService Alert { get; set; } = null!;
    
    
    #region Methods

    public async Task OnValidSubmitAsync()
    {
        try
        {
            var result = await _handler.CreateAsync(InputModel);
            if (result.IsSuccess)
            {
                _navigationManager.NavigateTo("/categorias");
                Alert.ShowAlert(result.Message ?? "Categoria criada com sucesso", AlertType.Success);
                InputModel = new();
            }
            else
            {
                Alert.ShowAlert(result.Message, AlertType.Danger);

            }
        }
        catch 
        {
            Alert.ShowAlert("Erro interno no servidor", AlertType.Danger);

        }
    }

    #endregion
}