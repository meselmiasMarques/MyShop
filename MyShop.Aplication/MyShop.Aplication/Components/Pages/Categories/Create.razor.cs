using Microsoft.AspNetCore.Components;
using MyShop.Core.Handlers;
using MyShop.Core.Requests.Categories;

namespace MyShop.Aplication.Components.Pages.Categories;

public partial class Create : ComponentBase
{
    [Parameter] public EditorCategoryRequest InputModel { get; set; }
    
    [Inject]
    private NavigationManager _navigationManager { get; set; }
    
    private string MessageSuccess =  string.Empty;
    private string MessageError = string.Empty;
    
    [Inject]
    private ICategoryHandler _handler { get; set; }
    
    
    #region Methods

    public async Task OnValidSubmitAsync()
    {
        try
        {
            var result = await _handler.CreateAsync(InputModel);
            if (result.IsSuccess)
            {
                MessageSuccess = result.Message;
                _navigationManager.NavigateTo("/categories");
            }
            else
            {
                MessageError = result.Message;
            }
        }
        catch 
        {
            
        }
    }

    #endregion
}