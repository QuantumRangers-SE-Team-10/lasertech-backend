using Microsoft.EntityFrameworkCore;

namespace lasertech_backend.Model;

public class GameContext: DbContext
{
    public  DbSet<Player> players { set; get; }

    public GameContext(DbContextOptions options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Configure the schema needed for the game here
        // For example, setting up table names, relationships, etc.
    }
}