namespace MyShop.Core.Requests.Identity;

public record RegisterRequest(string Email, string Password, string Name);