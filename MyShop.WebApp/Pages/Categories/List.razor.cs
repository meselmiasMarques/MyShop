using Microsoft.AspNetCore.Components;
using MyShop.App.Components;
using MyShop.Core.Handlers;
using MyShop.Core.Model;

namespace MyShop.App.Pages.Categories;

public partial class List : ComponentBase
{
    private ConfirmModal? confirmModal;
    private int _categoryToDelete;
    
    private List<Category> Categories { get; set; } = new();

    [Inject] 
    public ICategoryHandler Handler { get; set; } = null!;

    [Inject] private NavigationManager _navigationManager { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        var result = await Handler.GetAll();

        Categories = result.Data ?? [];
    }
    
    private void NewCategory()
    {
        _navigationManager.NavigateTo("categorias/cadastrar");
    }

    private void Edit(int id)
    {
        _navigationManager.NavigateTo($"categorias/atualizar/{id}");
    }
    
    private void Delete(int id)
    {
        _categoryToDelete = id;
        confirmModal?.Show();
    }
    
    private async Task HandleConfirmation(bool confirmed)
    {
        if (confirmed)
        {
           var result =  await Handler.DeleteAsync(_categoryToDelete);

           if (result.IsSuccess)
           {
               _navigationManager.Refresh();
           }
        }
    }
}