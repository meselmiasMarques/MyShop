using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MyShop.Api.Extensions;

public static class ModelStateExtension
{
    public static List<string> GetErros(this ModelStateDictionary modelState)
    {
        return (from item in modelState.Values from error 
            in item.Errors select error.ErrorMessage).ToList();
    }
}