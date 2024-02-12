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
    public IEnumerable<string> Get()
    {
        return new string[] { "Player 1", "player 2" };
    }

    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "player " + id;
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