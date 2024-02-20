using System.ComponentModel.DataAnnotations;
using lasertech_backend.DTOs;
using lasertech_backend.Migrations;

namespace lasertech_backend.Model;

public class Game
{
    [Key] public int GameID { get; set; }
    public int RedScore { get; set; }
    public int BlueScore { get; set; }
    public virtual ICollection<PlayerSession> PlayerSessions { get; set; } // one-to-many

    public Game()
    {
        BlueScore = 0;
        RedScore = 0;
        PlayerSessions = new List<PlayerSession>();
    }
}