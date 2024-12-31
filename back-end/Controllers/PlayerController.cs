using arcade.Models;
using arcade.ApplicationDbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace arcade.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController: ControllerBase
{
    private readonly ArcadeContext _db;
    
    public PlayerController(ArcadeContext db)
    {
        _db = db;
    }

    [HttpGet]
    [Route("test")]
    public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
    {
        return await _db.Players.ToListAsync();
    }

    [HttpGet()]
    [Route("login")]
    public async Task<ActionResult<string>> Login(string username, string password)
    {
        Player player = await _db.Players.FirstOrDefaultAsync(p => p.username == username && p.password == password);

        if (player == null) return BadRequest("Invalid Credentials");

        return "Logged In";
    }

    [HttpPost()]
    [Route("signup")]
    public async Task<IActionResult> Register(string username, string password)
    {
        Player player = await _db.Players.FirstOrDefaultAsync(p => p.username == username);

        if(player != null)
        {
            return BadRequest("username already exists");
        }

        _db.Players.Add(new Player(username, password));
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(Login), new { username = username, password = password  }, username); 
    }
}

