using lasertech_backend.Model;
using Microsoft.AspNetCore.Mvc;

namespace lasertech_backend.Controllers;



[Route("api/[controller]")]
[ApiController]
public class GameController: ControllerBase
{
    private readonly GameContext Context;

    public GameController(GameContext context)
    {
        this.Context = context;
    }
  
    [HttpGet]
    public List<Player> Get()
    {
        return Context.players.ToList();
    }

    [HttpGet("{playerID}")]
    public Player Get(int playerID)
    {
        return Context.players.Find(playerID)!;
    }

    [HttpPost]
    public Player Post(int playerID, string codename)
    {
        var player = new Player(playerID, codename);
        Context.Add(player);
        Context.SaveChanges();
        return player;
    }
    
}