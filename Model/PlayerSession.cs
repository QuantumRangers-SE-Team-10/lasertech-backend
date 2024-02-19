using System.ComponentModel.DataAnnotations;
using lasertech_backend.Enum;

namespace lasertech_backend.Model;

public class PlayerSession
{
    [Key]
    public int PlayerSessionID { get; set; }
    public int GameID { get; set; }
    public int PlayerID { get; set; }
    public int PlayerScore { get; set; }
    public TeamSide Team { get; set; }
    public int EquipmentID { get; set; }

    public PlayerSession(int gameID, int playerID, TeamSide team, int equipmentID)
    {
        GameID = gameID;
        PlayerID = playerID;
        Team = team;
        PlayerScore = 0;
        EquipmentID = equipmentID;
    }
}