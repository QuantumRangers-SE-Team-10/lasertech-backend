using lasertech_backend.DTOs;
using lasertech_backend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

    [HttpPost]
    public async Task<ActionResult<Game>> Post()
    {
        var game = new Game();
        Context.Add(game);
        await Context.SaveChangesAsync();
        return game;
    }
}