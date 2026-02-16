using Microsoft.AspNetCore.Components;
using MyShop.App.Components.Alerts.enums;
using MyShop.App.Components.Alerts.Services;
using MyShop.Core.Handlers;
using MyShop.Core.Model;
using MyShop.Core.Requests.ProductRequest;

namespace MyShop.App.Pages.Products;

public partial class Update : ComponentBase
{

    #region Properties

    [Parameter]
    public int Id { get; set; }

    [Parameter] public EditorProductRequest InputModel { get; set; } = new();

    private List<Category>? Categories { get; set; } = new();

    public string Message { get; set; } = string.Empty;
    
    #endregion


    #region Injects

    [Inject] 
    private NavigationManager NavigationManager { get; set; } = null!;
    
    [Inject]
    protected IProductHandler ProductHandler { get; set; } = null!;
    
    [Inject]
    protected ICategoryHandler CategoryHandler { get; set; } = null!;

    [Inject] 
    protected AlertService Alert { get; set; } = null!;

    #endregion

    #region Methods

    protected override async Task OnInitializedAsync()
    {
        InputModel.Id = Id;
        try
        {
            var result = await ProductHandler.GetByIdAsync(InputModel);
            if (result.IsSuccess)
            {
                InputModel.Name = result.Data?.Name;
                InputModel.Description = result.Data.Description;
                InputModel.Price = result.Data.Price;
                InputModel.ImageUrl = result.Data.ImageUrl;
                InputModel.CategoryId = result.Data.CategoryId;
            }

            var resultCategory = await CategoryHandler.GetAll();
            if (resultCategory.IsSuccess)
            {
                Categories = resultCategory.Data;
              
            }

        }
        catch (Exception e)
        {
            Message = e.Message;
        }

    }

    protected async Task OnValidSubmitAsync()
    {
        try
        {
            var result = await ProductHandler.UpdateAsync(InputModel, InputModel.Id);
            if (result.IsSuccess)
            {
                NavigationManager.NavigateTo("/produtos");
                Alert.ShowAlert(result.Message ?? "Produto atualizado com Sucesso !", AlertType.Info);
            }
            else
            {
                Alert.ShowAlert(result.Message ?? "Produto atualizado com Sucesso !", AlertType.Danger);
            }
        }
        catch (Exception e)
        {
            Alert.ShowAlert(e.Message ?? "Produto atualizado com Sucesso !", AlertType.Danger);
        }
    }

    #endregion
}