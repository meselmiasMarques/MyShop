using Microsoft.AspNetCore.Components;
using MyShop.Core.Handlers;
using MyShop.Core.Requests.Categories;

namespace MyShop.App.Pages.Categories;

public partial class Create : ComponentBase
{
    private string? message;
    
    [Parameter] 
    public EditorCategoryRequest InputModel { get; set; } = new();

    [Inject] private NavigationManager _navigationManager { get; set; } 


    [Inject] private ICategoryHandler _handler { get; set; } 
    
    
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
                message = "Erro ao cadastrar categoria.";
            }
        }
        catch 
        {
            message = "Erro ao cadastrar categoria.";
        }
    }

    #endregion
}