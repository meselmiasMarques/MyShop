using Microsoft.AspNetCore.Components;
using MyShop.App.Components.Alerts.enums;
using MyShop.App.Components.Alerts.Services;
using MyShop.Core.Handlers;
using MyShop.Core.Requests.Categories;

namespace MyShop.App.Pages.Categories;

public partial class Update : ComponentBase
{
    private string? _message = string.Empty;
    
    [Parameter]
    public int Id { get; set; }
    
    [Parameter] 
    public EditorCategoryRequest InputModel { get; set; } = new();

    [Inject] 
    private NavigationManager NavigationManager { get; set; } = null!;

    [Inject] 
    private ICategoryHandler Handler { get; set; } = null!;

    [Inject] protected AlertService Alert { get; set; } = null!;


    protected override async Task OnInitializedAsync()
    {
        InputModel.Id = Id;
        var result = await Handler.GetByIdAsync(InputModel);
        if (result.IsSuccess)
        {
            InputModel.Id = result.Data.Id;
            InputModel.Title = result.Data?.Title;
        }        
    }
    
    
    public async Task OnValidSubmitAsync()
    {
        try
        {
            var result = await Handler.UpdateAsync(InputModel,InputModel.Id);
            if (result.IsSuccess)
            {
                NavigationManager.NavigateTo("/categorias");
                Alert.ShowAlert(result.Message, AlertType.Success);
                InputModel = new();
            }
            else
            {
               Alert.ShowAlert(result.Message, AlertType.Warning);
            }
        }
        catch(Exception ex)
        {
            Alert.ShowAlert(ex.Message, AlertType.Danger);
        }
    }
}