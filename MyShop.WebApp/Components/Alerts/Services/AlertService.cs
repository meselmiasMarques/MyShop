using MyShop.App.Components.Alerts.enums;
using MyShop.App.Components.Alerts.Models;

namespace MyShop.App.Components.Alerts.Services;

public class AlertService
{
    public event Action<AlertMessage>? OnAlert;
    
    public void ShowAlert(string message , AlertType type){
        OnAlert?.Invoke(new AlertMessage
        {
            Type = type,
            Message = message
        });
    }

}