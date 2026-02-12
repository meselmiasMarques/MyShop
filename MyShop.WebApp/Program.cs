using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyShop.App;
using MyShop.App.Handlers;
using MyShop.Core.Handlers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient(Configuration.ApiName, client =>
    client.BaseAddress = new Uri(Configuration.Api));


builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
builder.Services.AddTransient<IProductHandler, ProductHandler>();



builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });




await builder.Build().RunAsync();