using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyShop.Api.Identity;
using MyShop.Core.Requests.Identity;
using TokenHandler = MyShop.Api.Handlers.TokenHandler;

namespace MyShop.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthController(
    UserManager<User> userManager, 
    SignInManager<User> signInManager, 
    TokenHandler tokenHandler)
    : ControllerBase
{
  

   // ==============================
    // REGISTER
    // ==============================
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = new User
        {
            UserName = model.Email,
            Email = model.Email,
            Name = model.Name
        };

        var result = await userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        var token = tokenHandler.GenerateToken(user);

        return Ok(new
        {
            token
        });
    }

    // ==============================
    // LOGIN
    // ==============================
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = await userManager.FindByEmailAsync(model.Email);

        if (user == null)
            return Unauthorized(new { message = "Usuário ou senha inválidos" });

        var result = await userManager.CheckPasswordAsync(
            user,
            model.Password);

        if (!result)
            return Unauthorized(new { message = "Usuário ou senha inválidos" });

        var token = tokenHandler.GenerateToken(user);

        return Ok(new
        {
            token
        });
    }

    // ==============================
    // ENDPOINT TESTE
    // ==============================
    [HttpGet("me")]
    [Microsoft.AspNetCore.Authorization.Authorize]
    public IActionResult Me()
    {
        return Ok(new
        {
            id = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value,
            email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value,
            name = User.Identity?.Name
        });
    }

    
}
