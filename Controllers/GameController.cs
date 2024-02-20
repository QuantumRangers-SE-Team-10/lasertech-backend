using lasertech_backend.Model;
using Microsoft.AspNetCore.Mvc;

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
    public List<Game> Get()
    {
        return Context.games.ToList();
    }

    [HttpGet("{gameID}")]
    public Game Get(int gameID)
    {
        return Context.games.Find(gameID)!;
    }

    [HttpPost]
    public Game Post()
    {
        var game = new Game();
        Context.Add(game);
        Context.SaveChanges();
        return game;
    }
    
    [HttpPost("{gameID}")]
    public Game Post(int gameID,PlayerSession playerSession)
    {
        var game = Context.games.Find(gameID)!;
        game.AddPlayerSessionTable(playerSession);
        Context.SaveChanges();
        return game;
    }
}