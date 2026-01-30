using MyShop.Core.Handlers;
using MyShop.Core.Model;
using MyShop.Core.Responses;

namespace MyShop.Aplication.Handlers;

public class CategoryHandler(IHttpClientFactory httpClientFactory) : ICategoryHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.ApiName);


    public async Task<Response<Category>> Create(Category category)
    {
        var result = await _client.PostAsJsonAsync("v1/categories", category);

        return await result.Content.ReadFromJsonAsync<Response<Category>>()
               ?? new Response<Category>("Erro ao Criar Categoria");
    }

    public Task<Response<Category>> Update(Category category, int id)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Category>> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Category>> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<List<Category>>> GetAll()
        => await _client.GetFromJsonAsync<
               Response<List<Category>>>("v1/categories")
           ?? new Response<List<Category>>("Erro ao recuperar categorias");
}