using Microsoft.AspNetCore.Components;
using MyShop.App.Components;
using MyShop.App.Components.Alerts.enums;
using MyShop.App.Components.Alerts.Services;
using MyShop.App.Handlers;
using MyShop.Core.Handlers;
using MyShop.Core.Model;
using MyShop.Core.Requests.ProductRequest;


namespace MyShop.App.Pages.Products;

public partial class List : ComponentBase
{
    private ConfirmModal? confirmModal;
    private int _productToDelete;
    
    private List<Product> Products { get; set; } = new();
    private string? Message { get; set; } = string.Empty;

    [Inject] private IProductHandler Handler { get; set; } = null!;

    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private AlertService Alert { get; set; } = null!;

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
                Alert.ShowAlert("Erro ao recuperar categorias", AlertType.Danger);
            }
        }
        catch
        {
            Alert.ShowAlert("Erro ao recuperar categorias", AlertType.Danger);
        }
    }

    private void Add()
    {
        NavigationManager.NavigateTo("produtos/cadastrar");
    }

    private void Edit(int id)
    {
        NavigationManager.NavigateTo($"produtos/atualizar/{id}");
    }

    private void Delete(int id)
    {
       _productToDelete = id;
       confirmModal?.Show();
    }

    private async Task HandleConfirmation(bool arg)
    {
        try
        {
            var request = new EditorProductRequest {Id =  _productToDelete};
            var result = await Handler.DeleteAsync(request);
            if (result.IsSuccess)
            {
                var product = Products.FirstOrDefault(product => product.Id == _productToDelete);
                Products.Remove(product);
                Alert.ShowAlert("Produto excluido com sucesso", AlertType.Info);
                
                StateHasChanged();
            }
        }
        catch (Exception e)
        {
            Alert.ShowAlert(e.Message ?? "Ocorreu um erro interno no servidor" , AlertType.Danger);
        }
    }
}