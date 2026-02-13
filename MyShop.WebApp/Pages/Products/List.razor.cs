using Microsoft.AspNetCore.Components;
using MyShop.Core.Handlers;
using MyShop.Core.Model;

namespace MyShop.App.Pages.Products;

public partial class List : ComponentBase
{
    private List<Product> Products { get; set; } = new();
    private string? Message { get; set; } = string.Empty;

    [Inject] private IProductHandler Handler { get; set; } = null!;

    [Inject] private NavigationManager NavigationManager { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            var result = await Handler.GetAll();

            if (result.IsSuccess)
            {
                Products = result.Data.OrderByDescending(product => product.Id).ToList() ?? [];
            }
            else
            {
                Message = "Ocorreu um erro inesperado";
            }
        }
        catch
        {
            Message = "Ocorreu um erro inesperado";
        }
    }

    private void Add()
    {
        NavigationManager.NavigateTo("produtos/cadastrar");
    }

    private void Edit(int id)
    {
    }

    private void Delete(int id)
    {
    }
}