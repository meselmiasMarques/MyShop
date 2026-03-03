using Microsoft.AspNetCore.Identity;

namespace MyShop.Api.Identity;

public class User : IdentityUser
{
    public string Name { get; set; } =  string.Empty;
}