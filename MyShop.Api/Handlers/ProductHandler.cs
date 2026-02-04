using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MyShop.Api.Repositories;
using MyShop.Core.Handlers;
using MyShop.Core.Model;
using MyShop.Core.Requests.Categories;
using MyShop.Core.Requests.ProductRequest;
using MyShop.Core.Responses;

namespace MyShop.Api.Handlers;

public class ProductHandler(ProductRepository repository) : IProductHandler
{
    private readonly ProductRepository _repository = repository;


    public async Task<Response<Product>> CreateAsync(EditorProductRequest model)
    {
        var product = new Product
        {
            Id = 0,
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            CategoryId = model.CategoryId
        };

        try
        {
            await _repository.CreateAsync(product);
            return new Response<Product>(product,201,"Produto criada com sucesso");
        }
        catch
        {
            return new Response<Product>(null,500,"Ocorreu um erro ao criar o Produto");
        }
        
    }

    public async Task<Response<Product>> UpdateAsync(EditorProductRequest model, int id)
    {
        var product = await _repository.GetAsync(id);
        if (product == null)
            return new Response<Product>(null, 404, "Produto não encontrada");
        
        product.Name = model.Name;
        product.Description = model.Description;
        product.Price = model.Price;
        product.CategoryId = model.CategoryId;
        
        
        await _repository.UpdateAsync(product);
        return new Response<Product>(product,200,"Produto atualizada com sucesso");
    }
    

    public async Task<Response<Product>> DeleteAsync(EditorProductRequest model)
    {
        var product = await _repository.GetAsync(model.Id);
        if (product == null)
            return new Response<Product>(null, 404, "Produto não encontrada");
        
        await _repository.DeleteAsync(product);
        
        return new Response<Product>(null, 200,"Produto excluido com sucesso");

    }

    public async Task<Response<Product>> GetByIdAsync(EditorProductRequest model)
    {
        var product = await _repository.GetAsync(model.Id);
        if (product == null)
            return new Response<Product>(null, 404, "Produto não encontrada");
        
        return new Response<Product>(product,200,"");

    }

    public async Task<Response<List<Product>>> GetAll()
    {
        try
        {
           var product = await _repository.GetAsync();
           return new Response<List<Product>>(product, 200);
        }
        catch
        {
            return new Response<List<Product>>(null, 500, "Erro ao carregar os dados");
        }
    }

    public async Task<Response<List<Product>>> GetAllByCategory(int categoryId)
    { 
        throw new NotImplementedException();
    }
}