using System.ComponentModel.DataAnnotations;
using lasertech_backend.DTOs;

namespace lasertech_backend.Model;

public class Player
{
    [Key] public int PlayerID { get; set; }

    [Required(ErrorMessage = "Codename is required")]
    [MinLength(3, ErrorMessage = "Codename need to be more than 3 character")]
    [MaxLength(50, ErrorMessage = "Codename cannot be more than 50 character")]
    public string Codename { get; set; }

    [DataType(DataType.DateTime, ErrorMessage = "Invalid datatype for LastUpdated")]
    public DateTime LastUpdated { get; set; }

    public Player(int playerID, string codename)
    {
        PlayerID = playerID;
        Codename = codename;
        LastUpdated = DateTime.UtcNow;
    }

    public Player(PlayerDTO playerDTO)
    {
        PlayerID = playerDTO.PlayerID;
        Codename = playerDTO.Codename;
        LastUpdated = DateTime.UtcNow;
    }
}