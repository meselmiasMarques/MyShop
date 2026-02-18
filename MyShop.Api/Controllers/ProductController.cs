using Microsoft.AspNetCore.Mvc;
using MyShop.Api.Extensions;
using MyShop.Core.Handlers;
using MyShop.Core.Model;
using MyShop.Core.Requests;
using MyShop.Core.Requests.ProductRequest;
using MyShop.Core.Responses;

namespace MyShop.Api.Controllers;

[ApiController]
public class ProductController(IProductHandler handler) : ControllerBase
{
    private readonly IProductHandler _handler = handler;


    [HttpPost("v1/products")]
    public async Task<IActionResult> PostAsync([FromBody]  EditorProductRequest Request)
    {
        if(!ModelState.IsValid)
            return BadRequest(new Response<dynamic>(null,500,
                ModelState.GetErros().ToString()));
        var result =  await _handler.CreateAsync(Request);
        
        return Created($"{result.Data?.Id}", result);
    }
    
    [HttpPut("v1/products/{id:int}")]
    public async Task<IActionResult> PutAsync([FromBody]  EditorProductRequest request, int id)
    {

        try
        {
            if (!ModelState.IsValid)
                return BadRequest(new Response<dynamic>(null, 500,
                    ModelState.GetErros().ToString()));
            var result = await _handler.UpdateAsync(request, id);

            return Ok(new Response<dynamic>(result, 200, "Produto atualizado com sucesso"));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<dynamic>( null,500, "Erro interno no servidor"));

        }
    }

    [HttpGet("v1/products")]
    public async Task<IActionResult> GetAsync()
    {
        var result = await _handler.GetAll();

        return Ok(result);
    }
    
    [HttpGet("v1/products/{id:int}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var request = new EditorProductRequest { Id = id };
        var result = await _handler.GetByIdAsync(request);
        return Ok(result);
    }
    
    [HttpDelete("v1/products/{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var request = new EditorProductRequest { Id = id };
        var result = await _handler.DeleteAsync(request);
        return Ok(result);
    }
    
    [HttpPut("v1/products/uploadImage/{id:int}")]
    public async Task<IActionResult> UploadImageAsync([FromBody]  UploadImageViewModel request, int id)
    {

        try
        {
            if (!ModelState.IsValid)
                return BadRequest(new Response<dynamic>(null, 500,
                    ModelState.GetErros().ToString()));
            var result = await _handler.UploadImage(request, id);

            return Ok(new Response<dynamic>(result, 200, "Imagem atualizada com sucesso"));
        }
        catch (Exception e) 
        {
            return BadRequest(new Response<dynamic>( null,500, "Erro interno no servidor"));

        }
    }
}