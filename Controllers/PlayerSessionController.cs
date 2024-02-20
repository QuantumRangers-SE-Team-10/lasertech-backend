using lasertech_backend.DTOs;
using lasertech_backend.Model;
using Microsoft.AspNetCore.Mvc;

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

    [HttpPost]
    public async Task<ActionResult<PlayerSession>> Post(PlayerSession playerSession)
    {
        Context.Add(playerSession);
        await Context.SaveChangesAsync();
        return Ok(playerSession);
    }
}