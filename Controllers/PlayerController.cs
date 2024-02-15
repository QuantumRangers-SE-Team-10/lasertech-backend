using lasertech_backend.Model;
using Microsoft.AspNetCore.Mvc;

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
    public List<Player> Get()
    {
        return Context.players.ToList();
    }

    [HttpGet("{id}")]
    public Player Get(int id)
    {
        return Context.players.Find(id)!;
    }

    [HttpPost]
    public Player Post(int playerID, string codename)
    {
        var player = new Player(playerID, codename);
        Context.Add(player);
        Context.SaveChanges();
        return player;
    }

    [HttpPut("{id}")]
    public Player Put(int id, string newCodename)
    {
        var player = Context.players.Find(id)!;
        player.Codename = newCodename;
        player.LastUpdated = DateTime.UtcNow;
        Context.SaveChanges();
        return player;
    }
}