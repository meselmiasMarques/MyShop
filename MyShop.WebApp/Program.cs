using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyShop.App;
using MyShop.App.Auth;
using MyShop.App.Components.Alerts.Services;
using MyShop.App.Handlers;
using MyShop.Core.Handlers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


// ----------------------------
// 🔐 AUTH CONFIG
// ----------------------------

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

builder.Services.AddScoped<AuthMessageHandler>();


// ----------------------------
// 🌐 HTTP CLIENT (API)
// ----------------------------

builder.Services.AddHttpClient("Api", client =>
    {
        client.BaseAddress = new Uri(Configuration.Api);
    })
    .AddHttpMessageHandler<AuthMessageHandler>();

// HttpClient padrão que será usado pelos handlers
builder.Services.AddScoped(sp =>
{
    var factory = sp.GetRequiredService<IHttpClientFactory>();
    return factory.CreateClient("Api");
});


// ----------------------------
// 🧠 HANDLERS
// ----------------------------

builder.Services.AddScoped<ICategoryHandler, CategoryHandler>();
builder.Services.AddScoped<IProductHandler, ProductHandler>();
builder.Services.AddScoped<AuthHandler>();


// ----------------------------
// 📢 SERVICES
// ----------------------------

builder.Services.AddScoped<AlertService>();


await builder.Build().RunAsync();