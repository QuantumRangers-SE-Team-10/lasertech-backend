using lasertech_backend.DTOs;
using lasertech_backend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace lasertech_backend.Controllers;

[Route("api/[controller]")]
[ApiController]

public class PlayerSessionController : ControllerBase
{
    private readonly GameContext Context;

    public PlayerSessionController(GameContext context)
    {
        this.Context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<PlayerSession>>> Get()
    {
        var player = await Context.playerSessions.ToListAsync();
        return Ok(player);
    }

    [HttpGet("{playerSessionID}")]
    public async Task<ActionResult<Player>> Get(int playerSessionID)
    {
        var playerSession = await Context.playerSessions.FindAsync(playerSessionID);
        if (playerSession != null)
        {
            return Ok(playerSession);
        }
        else
        {
            return NotFound(playerSession);
        }

    }


    [HttpPost]
    public async Task<ActionResult<PlayerSession>> Post([FromBody] PlayerSessionDTO playerSessionDTO)
    {
        var playerSession = new PlayerSession(playerSessionDTO);
        var checkPlayer = await Context.playerSessions.FindAsync(playerSession.PlayerID);
        if (checkPlayer == null)
        {
            Context.Add(playerSession);
            await Context.SaveChangesAsync();

            return Ok(playerSession);
        }
        else
        {
            return Conflict(playerSession);
        }
    }


    [HttpDelete("{playerSessionID}")]
    public async Task<ActionResult> Delete(int playerSessionID)
    {
        var playerToDelete = await Context.playerSessions.FindAsync(playerSessionID);

        if (playerToDelete == null)
        {
            return NotFound();
        }
        Context.playerSessions.Remove(playerToDelete);
        await Context.SaveChangesAsync();

        return Ok(playerToDelete);
    }
}