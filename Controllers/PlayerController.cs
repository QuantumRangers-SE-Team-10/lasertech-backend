using Microsoft.AspNetCore.Mvc;

namespace lasertech_backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlayerController : ControllerBase
{
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
        return "player " + codename + " created";
    }

    [HttpPut("{id}")]
    public string Put(int id)
    {
        return "user " + id + " updated";
    }
}