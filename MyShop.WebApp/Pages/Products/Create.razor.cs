using Microsoft.AspNetCore.Components;
using MyShop.Core.Handlers;
using MyShop.Core.Model;
using MyShop.Core.Requests.ProductRequest;

namespace MyShop.App.Pages.Products;

public partial class Create : ComponentBase
{
    #region Properties

    [Parameter] public EditorProductRequest InputModel { get; set; } = new();
    
    [Parameter]
    public List<Category> Categories { get; set; } = new ();

    private string Message { get; set; } = string.Empty;
    
    #endregion
    
    #region Injects

    [Inject] protected IProductHandler ProductHandler { get; set; } = null!;
    [Inject] protected ICategoryHandler CategoryHandler { get; set; } = null!;
    [Inject] protected NavigationManager NavigationManager { get; set; } = null!;

    #endregion
    
    #region Methods

    protected override async Task OnInitializedAsync()
    {
        var result = await CategoryHandler.GetAll();
        if (result.IsSuccess)
        {
            Categories = result.Data ?? [];
        }
        else
        {
            Message = result.Message ?? "Erro Ao Recuperar Categorias";
        }
    }

    public async Task OnValidSubmitAsync()
    {
        var result = await ProductHandler.CreateAsync(InputModel);
        if (result.IsSuccess)
        {
            Message = result.Message ?? "Sucesso";
            NavigationManager.NavigateTo("/produtos");
        }
        else
        {
            Message = result.Message ?? "Erro Ao Inserir Produto";
        }
    }

    #endregion
}