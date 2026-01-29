using Microsoft.AspNetCore.Mvc;

namespace MyShop.Api.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
    public  HomeController()
    {}

    [HttpGet("")]
    public IActionResult Get()
    {
        var message = "Check api ok";
        return Ok(message);
    }

}