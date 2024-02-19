using System.ComponentModel.DataAnnotations;

namespace lasertech_backend.Model;

public class Game
{
    [Key] public int GameID { get; set; }
    public int RedScore { get; set; }
    public int BlueScore { get; set; }

    public Game()
    {
        BlueScore = 0;
        RedScore = 0;
    }
}