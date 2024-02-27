using lasertech_backend.DTOs;
using lasertech_backend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace lasertech_backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GameController : ControllerBase
{
    private readonly GameContext Context;

    public GameController(GameContext context)
    {
        this.Context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Game>>> Get()
    {
        var games = await Context.games.ToListAsync();
        return Ok(games);
    }

    [HttpGet("{gameID}")]
    public async Task<ActionResult<Game>> Get(int gameID)
    {
        var game = await Context.games
            .Include(g => g.PlayerSessions)
            .FirstOrDefaultAsync(g => g.GameID == gameID);
        return Ok(game);
    }
    [HttpGet("{gameID}/codenames")]
    public async Task<ActionResult<List<string>>> GetCodeNames(int gameID)
    {
        var game = await Context.games
            .Include(g => g.PlayerSessions)
            .FirstOrDefaultAsync(g => g.GameID == gameID);
        List<string> codeNames = new List<string>();
        foreach (PlayerSession playerSession in game.PlayerSessions)
        {
            var player = await Context.players.FindAsync(playerSession.PlayerID);
            codeNames.Add(player.Codename);
        }

        return Ok(codeNames);
    
    }

    [HttpPost]
    public async Task<ActionResult<Game>> Post()
    {
        var game = new Game();
        Context.Add(game);
        await Context.SaveChangesAsync();
        return Ok(game);
    }
    [HttpPost("{gameID}/{playerID}")]
    public async Task<ActionResult<Game>> Post(int gameID, [FromBody] PlayerSession playerSession)
    {
        var game = await Context.games
            .Include(g => g.PlayerSessions)
            .FirstOrDefaultAsync(g => g.GameID == gameID);
        game.PlayerSessions.Add(playerSession);
        await Context.SaveChangesAsync();
        return Ok(game);

    }
}