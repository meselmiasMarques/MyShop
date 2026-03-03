using System.Net.Http.Json;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using MyShop.App.Auth;
using MyShop.Core.Requests.Identity;
using MyShop.Core.Responses;

namespace MyShop.App.Handlers;

public class AuthHandler(HttpClient http, 
    ILocalStorageService localStorage, 
    AuthenticationStateProvider authStateProvider)
{

    public async Task<bool> Login(LoginRequest model)
    {
        var response = await http.PostAsJsonAsync("/api/Auth/login",model);

        if (!response.IsSuccessStatusCode)
            return false;
        
        var result  =  await response.Content.ReadFromJsonAsync<LoginResponse>();
        await localStorage.SetItemAsync("authToken", result!.Token);

        ((CustomAuthStateProvider)authStateProvider)
            .NotifyUserAuthentication(result.Token);

        return true;

    }
    
    public async Task LogoutAsync()
    {
        await localStorage.RemoveItemAsync("authToken");
        ((CustomAuthStateProvider)authStateProvider).NotifyUserLogout();
    }


}