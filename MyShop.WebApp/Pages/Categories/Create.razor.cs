using Microsoft.AspNetCore.Components;
using MyShop.Core.Handlers;
using MyShop.Core.Requests.Categories;

namespace MyShop.App.Pages.Categories;

public partial class Create : ComponentBase
{
    [Parameter] 
    public EditorCategoryRequest InputModel { get; set; } = new();
    
    [Inject]
    private NavigationManager _navigationManager { get; set; }
    
    
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
                _navigationManager.NavigateTo("/categories");
            }
            else
            {
             
            }
        }
        catch 
        {
            
        }
    }

    #endregion
}