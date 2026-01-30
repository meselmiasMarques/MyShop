using Azure;
using Microsoft.AspNetCore.Mvc;
using MyShop.Api.Repositories;
using MyShop.Core.Model;
using MyShop.Core.Requests.Categories;
using MyShop.Core.Responses;

namespace MyShop.Api.Controllers;

[ApiController]
public class CategoryController(
    ILogger<CategoryController> logger, 
    CategoryRepository repository)
    : ControllerBase
{
    private readonly ILogger<CategoryController> _logger = logger;
    private readonly CategoryRepository _repository = repository;

    [HttpGet("v1/categories")]
    public async Task<IActionResult> GetAsync()
    {
        try
        {
            var categories = await _repository.GetAsync();
            return Ok(new Core.Responses.Response<List<Category>>(categories));
        }
        catch 
        {
          return StatusCode(500, new Core.Responses.Response<List<Category>>("Erro ao recuperar Categorias"));
        }
        
    }
    
    [HttpGet("v1/categories{id:int}")]
    public async Task<IActionResult> GetIdAsync(int id)
    {
        try
        {
            var category = await _repository.GetAsync(id);

            if (category == null)
                return StatusCode(404, new Core.Responses.Response<Category>("Categoria não encontrada"));

            return Ok(new Core.Responses.Response<Category>(category));
        }
        catch 
        {
            return StatusCode(500, new Core.Responses.Response<List<Category>>("Erro ao recuperar Categorias"));
        }
    }

    [HttpPost("v1/categories")]
    public async Task<IActionResult> PostAsync([FromBody] EditorCategoryRequest model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var category = new Category
        {
            Id = 0,
            Title = model.Title
        };

         await _repository.CreateAsync(category);
         return Ok(new Core.Responses.Response<Category>(category));
    }
    
    [HttpPut("v1/categories/{id:int}")]
    public async Task<IActionResult> PutAsync([FromBody] EditorCategoryRequest model, int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var category = await _repository.GetAsync(id);
        if (category == null)
            return NotFound(new Core.Responses.Response<Category>("Categoria não encontrada"));
        
        category.Title = model.Title;
        
        await _repository.UpdateAsync(category);
        return Ok(new Core.Responses.Response<Category>(category));
    }
    
    [HttpDelete("v1/categories/{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var category = await _repository.GetAsync(id);
        if (category == null)
            return NotFound(new Core.Responses.Response<Category>("Categoria não encontrada"));
        
        await _repository.DeleteAsync(category);
        return Ok(new Core.Responses.Response<Category>(category));
    }

}