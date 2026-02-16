using MyShop.App.Components.Alerts.enums;

namespace MyShop.App.Components.Alerts.Models;

public class AlertMessage
{
    public string Message { get; set; } = string.Empty;
    public AlertType Type { get; set; }
}