using Microsoft.AspNetCore.Components;

namespace MyShop.App.Components;


public partial class ConfirmModal
{
    [Parameter] public string Title { get; set; } = "Confirmação";
    [Parameter] public string Message { get; set; } = "Deseja continuar?";
    [Parameter] public EventCallback<bool> OnClose { get; set; }

    public bool IsVisible { get; private set; }

    public void Show()
    {
        IsVisible = true;
        StateHasChanged();
    }

    private async Task Confirm()
    {
        IsVisible = false;
        await OnClose.InvokeAsync(true);
    }

    private async Task Cancel()
    {
        IsVisible = false;
        await OnClose.InvokeAsync(false);
    }
}
