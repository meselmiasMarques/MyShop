using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MyShop.Api.Repositories;
using MyShop.Core.Handlers;
using MyShop.Core.Model;
using MyShop.Core.Requests.Categories;
using MyShop.Core.Responses;

namespace MyShop.Api.Handlers;

public class CategoryHandler(CategoryRepository repository) : ICategoryHandler
{
    private readonly CategoryRepository _repository = repository;


    public async Task<Response<Category>> CreateAsync(EditorCategoryRequest model)
    {
        var category = new Category
        {
            Id = 0,
            Title = model.Title
        };

        try
        {
            await _repository.CreateAsync(category);
            return new Response<Category>(category,201,"Categoria criada com sucesso");
        }
        catch
        {
            return new Response<Category>(null,500,"Ocorreu um erro ao criar o Categoria");
        }
        
    }

    public async Task<Response<Category>> UpdateAsync(EditorCategoryRequest model, int id)
    {
        var category = await _repository.GetAsync(id);
        if (category == null)
            return new Response<Category>(null, 404, "Categoria não encontrada");
        
        category.Title = model.Title;
        
        await _repository.UpdateAsync(category);
        return new Response<Category>(category,200,"Categoria atualizada com sucesso");
    }
    

    public async Task<Response<Category>> DeleteAsync(EditorCategoryRequest model)
    {
        var category = await _repository.GetAsync(model.Id);
        if (category == null)
            return new Response<Category>(null, 404, "Categoria não encontrada");
        
        await _repository.DeleteAsync(category);
        
        return new Response<Category>(null, 200,"Categoria excluido com sucesso");

    }

    public async Task<Response<Category>> DeleteAsync(int id)
    {
        var category = await _repository.GetAsync(id);
        if (category == null)
            return new Response<Category>(null, 404, "Categoria não encontrada");
        
        await _repository.DeleteAsync(category);
        
        return new Response<Category>(null, 200,"Categoria excluido com sucesso");

    }
    
    public async Task<Response<Category>> GetByIdAsync(EditorCategoryRequest model)
    {
        var category = await _repository.GetAsync(model.Id);
        if (category == null)
            return new Response<Category>(null, 404, "Categoria não encontrada");
        
        return new Response<Category>(category,200,"");

    }

    public async Task<Response<List<Category>>> GetAll()
    {
        try
        {
           var categories = await _repository.GetAsync();
           return new Response<List<Category>>(categories, 200);
        }
        catch
        {
            return new Response<List<Category>>(null, 500, "Erro ao carregar os dados");
        }
    }
}