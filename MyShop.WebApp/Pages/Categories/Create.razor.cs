using Microsoft.AspNetCore.Components;
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
    
    
    #region Methods

    public async Task OnValidSubmitAsync()
    {
        try
        {
            var result = await _handler.CreateAsync(InputModel);
            if (result.IsSuccess)
            {
                _navigationManager.NavigateTo("/categorias");
                message = "Categoria cadastrada com sucesso!";
                InputModel = new();
            }
            else
            {
                message = result.Message;
            }
        }
        catch 
        {
            message = "Erro ao cadastrar categoria.";
        }
    }

    #endregion
}