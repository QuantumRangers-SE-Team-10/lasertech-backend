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
        var players = Context.players.ToList();
        return players;
    }

    [HttpGet("{id}")]
    public Player Get(int id)
    {
        var player = Context.players.Find(id);
        return player;
    }

    [HttpPost]
    public string Post(string codename)
    {
        var temp = new Player(codename);
        Context.Add(temp);
        Context.SaveChanges();
        return "player " + codename + " created";
    }

    [HttpPut("{id}")]
    public string Put(int id)
    {
        return "user " + id + " updated";
    }
}