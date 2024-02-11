using Microsoft.EntityFrameworkCore;

namespace lasertech_backend.Model;

public class GameContext : DbContext
{
    private DbSet<Player> players { set; get; }

    public GameContext(DbContextOptions<GameContext> options) : base(options)
    {
    }
}