using System.Net.Http.Json;
using MyShop.Core.Handlers;
using MyShop.Core.Model;
using MyShop.Core.Requests;
using MyShop.Core.Requests.ProductRequest;
using MyShop.Core.Responses;

namespace MyShop.App.Handlers;

public class ProductHandler (IHttpClientFactory httpClientFactory) : IProductHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.ApiName);

    public async Task<Response<Product>> CreateAsync(EditorProductRequest model)
    {
        var result = await _client.PostAsJsonAsync("v1/products", model);
        
        return  await result.Content.ReadFromJsonAsync<Response<Product>>() 
                ?? new Response<Product>(null, 400, "Ocorreu um erro ao tentar criar o produto");
    }

    public async Task<Response<Product>> UpdateAsync(EditorProductRequest model, int id)
    {
        var result = await _client.PutAsJsonAsync($"v1/products/{id}", model);
        return await result.Content.ReadFromJsonAsync<Response<Product>>()
            ?? new Response<Product>(null, 400, "Ocorreu um erro ao tentar atualizar o produto");
    }

    public async Task<Response<Product>> DeleteAsync(EditorProductRequest model)
    {
        var result = await _client.DeleteAsync($"v1/products/{model.Id}");
        return await result.Content.ReadFromJsonAsync<Response<Product>>() 
               ?? new Response<Product>(null, 400, "Ocorreu um erro ao tentar deletar o produto");
    }

    public async Task<Response<Product>> GetByIdAsync(EditorProductRequest model)
    {
        var result = await _client.GetAsync($"v1/products/{model.Id}");
        return await result.Content.ReadFromJsonAsync<Response<Product>>() 
            ?? new Response<Product>(null, 400, "Ocorreu um erro ao tentar obter o produto");
    }

    public async Task<Response<List<Product>>> GetAll()
    {
        var result  = await _client.GetAsync("v1/products");
        return await result.Content.ReadFromJsonAsync<Response<List<Product>>>()
            ?? new Response<List<Product>>(null, 400, "Erro ao recuperar Lista de produtos");
    }

    public async Task<Response<List<Product>>> GetAllByCategory(int categoryId)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Product>> UploadImage(UploadImageViewModel model, int id)
    {
        throw new NotImplementedException();
    }
}