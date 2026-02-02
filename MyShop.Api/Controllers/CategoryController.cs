using Azure;
using Microsoft.AspNetCore.Mvc;
using MyShop.Api.Extensions;
using MyShop.Api.Handlers;
using MyShop.Api.Repositories;
using MyShop.Core.Handlers;
using MyShop.Core.Model;
using MyShop.Core.Requests.Categories;
using MyShop.Core.Responses;

namespace MyShop.Api.Controllers;

[ApiController]
public class CategoryController(
    ILogger<CategoryController> logger, 
    ICategoryHandler handler)
    : ControllerBase
{
    private readonly ILogger<CategoryController> _logger = logger;
    private readonly ICategoryHandler _handler = handler;
    
    [HttpPost("v1/categories")]
    public async Task<IActionResult> PostAsync([FromBody] EditorCategoryRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
       var result  = await _handler.CreateAsync(request);
       return result.IsSuccess ? Created($"/{result.Data?.Id}", result) :  BadRequest(result);
    }
    
    [HttpGet("v1/categories")]
    public async Task<IActionResult> GetAsync()
    {
        var result = await _handler.GetAll();
        
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    
    [HttpGet("v1/categories/{id:int}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var request = new EditorCategoryRequest { Id = id };
        var result = await _handler.GetByIdAsync(request);
        
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    
    [HttpPut("v1/categories/{id:int}")]
    public async Task<IActionResult> PutAsync([FromBody] EditorCategoryRequest request, int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new Core.Responses.Response<dynamic>(ModelState.GetErros()));
        }
        
        await _handler.UpdateAsync(request, id);
        return Ok(new Core.Responses.Response<Category>(null,200,"Categoria atualizada com sucesso"));
    }
    
    [HttpDelete("v1/categories/{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var request = new EditorCategoryRequest
        {
            Id = id
        };
        await _handler.DeleteAsync(request);
        return Ok(new Core.Responses.Response<dynamic>(null,200,"Categoria removida com sucesso"));
    }

}