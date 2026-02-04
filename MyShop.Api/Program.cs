using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using MyShop.Api.Data;
using MyShop.Api.Handlers;
using MyShop.Api.Repositories;
using MyShop.Core.Handlers;
using MyShop.Core.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

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


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyShop");
        c.RoutePrefix = string.Empty;
    });
}

app.MapControllers();
app.Run();
