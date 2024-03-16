using Microsoft.EntityFrameworkCore;

namespace lasertech_backend.Model;

public class GameContext : DbContext
{
    public GameContext(DbContextOptions<GameContext> options) : base(options)
    {
    }
    
    public DbSet<Player> players { set; get; }
    public DbSet<Game> games { set; get; }
    public DbSet<PlayerSession> playerSessions { set; get; }
}