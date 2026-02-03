using Microsoft.AspNetCore.Components;
using MyShop.Core.Handlers;
using MyShop.Core.Model;

namespace MyShop.Aplication.Components.Pages.Categories;

public partial class GetAll : ComponentBase
{
    private List<Category> Categories { get; set; } = new();

    [Inject] 
    public ICategoryHandler Handler { get; set; } = null!;
    
    [Inject]
    private NavigationManager _navigationManager { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var result = await Handler.GetAll();

        Categories = result.Data ?? [];
    }
    
    private void NewCategory()
    {
        Console.Write("chamou aqui");
        _navigationManager.NavigateTo("/categorias/cadastrar");
    }
}