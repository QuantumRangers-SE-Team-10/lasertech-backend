using lasertech_backend.Enum;

namespace lasertech_backend.DTOs;

public class PlayerSessionDTO
{
    public int GameID { get; set; }
    public int PlayerID { get; set; }
    public int PlayerScore { get; set; }
    public TeamSide Team { get; set; }
    public int EquipmentID { get; set; }
}