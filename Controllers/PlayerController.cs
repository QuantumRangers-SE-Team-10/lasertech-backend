using lasertech_backend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lasertech_backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlayerController : ControllerBase
{
    private readonly GameContext Context;

    public PlayerController(GameContext context)
    {
        this.Context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Player>>> Get()
    {
        var player = await Context.players.ToListAsync();
        return Ok(player);
    }

    [HttpGet("{playerID}")]
    public async Task<ActionResult<Player>> Get(int playerID)
    {
        var player = await Context.players.FindAsync(playerID);
        return Ok(player);
    }

    [HttpPost]
    public async Task<ActionResult<Player>> Post([FromBody] Player player)
    {
        Context.Add(player);
        await Context.SaveChangesAsync();
        return Ok(player);
    }

    [HttpPut("{playerID}")]
    public async Task<ActionResult> Put(int playerID, [FromBody] string newCodename)
    {
        var player = await Context.players.FindAsync(playerID)!;
        player.Codename = newCodename;
        player.LastUpdated = DateTime.UtcNow;
        await Context.SaveChangesAsync();
        return NoContent();
    }
}