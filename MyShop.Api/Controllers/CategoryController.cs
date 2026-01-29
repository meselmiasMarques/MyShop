using Microsoft.AspNetCore.Mvc;
using MyShop.Api.Repositories;

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
        var categories = await _repository.GetAsync();
        return Ok(categories);
    }
}