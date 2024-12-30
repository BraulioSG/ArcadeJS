using arcade.Models;
using arcade.Services;
using Microsoft.AspNetCore.Mvc;

namespace arcade.Controllers;

[ApiController]
[Route("auth")]
public class AuthController: ControllerBase
{
    public AuthController()
    {
    }

    [HttpGet()]
    [Route("login")]
    public ActionResult<string> Login(string username, string password)
    {
        Console.WriteLine(username);
        return username;
    }

    [HttpPost()]
    [Route("signup")]
    public IActionResult Register(string username, string password)
    {
        AuthService.RegisterUser(username, password);
        return CreatedAtAction(nameof(Login), new { username = username, password = password }, username); 

    }


}

