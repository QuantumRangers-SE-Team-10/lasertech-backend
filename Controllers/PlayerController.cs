using lasertech_backend.DTOs;
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

        if (player == null)
        {
            return NotFound($"Player with ID {playerID} not found.");
        }

        return Ok(player);
    }

    [HttpPost]
    public async Task<ActionResult<Player>> Post(PlayerDTO p)
    {
        var player = new Player(p);

        if (ModelState.IsValid)
        {
            var checkPlayer = await Context.players.FindAsync(player.PlayerID);
            if (checkPlayer == null)
            {
                Context.Add(player);
                await Context.SaveChangesAsync();

                return Ok(player);
            }
            else
            {
                return Conflict(player);
            }
        }
        {
            // Handle validation errors
            var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
            return BadRequest(errors);
        }

    }

    [HttpPut("{playerID}")]
    public async Task<ActionResult> Put(PlayerDTO p)
    {
        var player = await Context.players.FindAsync(p.playerID)!;
        if (player != null)
        {
            player.Codename = p.Codename;
            player.LastUpdated = DateTime.UtcNow;
            await Context.SaveChangesAsync();
            return NoContent();
        }
        else
        {
            return NotFound(player);
        }
        
    }

    [HttpDelete("{playerID}")]
    public async Task<ActionResult> Delete(int playerID)
    {
        var playerToDelete = await Context.players.FindAsync(playerID);

        if (playerToDelete == null)
        {
            return NotFound();
        }
        Context.players.Remove(playerToDelete);

        await Context.SaveChangesAsync();

        return Ok(playerToDelete);
    }
}