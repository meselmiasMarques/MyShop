using Microsoft.EntityFrameworkCore;
using MyShop.Api.Data;
using MyShop.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbcontext>(options =>
{
    options.UseSqlServer(connectionString);
});


builder.Services.AddTransient<CategoryRepository>();

var app = builder.Build();


app.MapControllers();
app.Run();
