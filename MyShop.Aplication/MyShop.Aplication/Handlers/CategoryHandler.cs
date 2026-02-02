using MyShop.Core.Handlers;
using MyShop.Core.Model;
using MyShop.Core.Requests.Categories;
using MyShop.Core.Responses;

namespace MyShop.Aplication.Handlers;

public class CategoryHandler(IHttpClientFactory httpClientFactory) : ICategoryHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.ApiName);


    public async Task<Response<Category>> Create(EditorCategoryRequest request)
    {
        var result = await _client.PostAsJsonAsync("api/Category", request);
        
        return await result.Content.ReadFromJsonAsync<Response<Category?>>() 
            ?? new Response<Category?>(null,400,"Falha ao Criar Categoria");
    }

    public async Task<Response<Category>> Update(EditorCategoryRequest model)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Category>> Delete(EditorCategoryRequest model)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Category>> GetById(EditorCategoryRequest model)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<List<Category>>> GetAll()
    {
        throw new NotImplementedException();
    }
}