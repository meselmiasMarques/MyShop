using Microsoft.AspNetCore.Http.HttpResults;
using MyShop.Core.Handlers;
using MyShop.Core.Model;
using MyShop.Core.Requests.Categories;
using MyShop.Core.Responses;

namespace MyShop.Aplication.Handlers;

public class CategoryHandler(IHttpClientFactory httpClientFactory) : ICategoryHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.ApiName);


    public async Task<Response<Category>> CreateAsync(EditorCategoryRequest request)
    {
        var result = await _client.PostAsJsonAsync("v1/categories", request);
        
        return await result.Content.ReadFromJsonAsync<Response<Category?>>() 
               ?? new Response<Category?>(null,400,"Falha ao Criar Categoria");
    }

    public async Task<Response<Category>> UpdateAsync(EditorCategoryRequest model, int id)
    {
        var  result = await _client.PutAsJsonAsync("v1/categories/" + id, model);
        return await result.Content.ReadFromJsonAsync<Response<Category>>() 
               ?? new Response<Category>(null,400,"Falha ao Atualizar Categoria");
    }

    public async Task<Response<Category>> DeleteAsync(EditorCategoryRequest model)
    {
       var result = await _client.DeleteAsync($"v1/categories/{model.Id}");
       return await result.Content.ReadFromJsonAsync<Response<Category>>() 
              ?? new Response<Category>(null,400,"Falha ao carregar Categoria");
    }

    public async Task<Response<Category>> GetByIdAsync(EditorCategoryRequest model)
    {
        var result = await _client.GetAsync($"v1/categories/{model.Id}");
        return await result.Content.ReadFromJsonAsync<Response<Category>>() 
               ?? new Response<Category>(null,400,"Falha ao Obter Categoria");
        
    }

    public async Task<Response<List<Category>>> GetAll()
    {
        var result = await _client.GetAsync("v1/categories");
        return await result.Content.ReadFromJsonAsync<Response<List<Category>>>() 
               ?? new Response<List<Category>>(null,400,"Falha ao carregar Categoria");
    }
}