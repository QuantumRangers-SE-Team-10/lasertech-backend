using Microsoft.EntityFrameworkCore;

namespace lasertech_backend.Model;

public class GameContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public GameContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var connectionString = Configuration.GetConnectionString("GameContext");
        options.UseNpgsql(connectionString);
    }

    public DbSet<Player> players { set; get; }
}