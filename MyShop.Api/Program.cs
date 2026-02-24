

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyShop.Api.Data;
using MyShop.Api.Handlers;
using MyShop.Api.Repositories;
using MyShop.Core.Handlers;
using MyShop.Core.Model;

var builder = WebApplication.CreateBuilder(args);

// 1️⃣ Adiciona política de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:5174")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler =
        System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});;

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbcontext>(options =>
{
    options.UseSqlServer(connectionString);
});


builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
builder.Services.AddTransient<IProductHandler, ProductHandler>();

builder.Services.AddTransient<CategoryRepository>();
builder.Services.AddTransient<ProductRepository>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(p =>
{
    p.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MyShop API",
        Version = "v1",
        Description = "MyShop API"
        
    });
});

var app = builder.Build();

app.UseStaticFiles();


{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyShop");
        c.RoutePrefix = string.Empty;
    });
}

app.UseCors("AllowBlazorApp");
app.MapControllers();
app.Run();
