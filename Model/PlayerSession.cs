using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using lasertech_backend.DTOs;
using lasertech_backend.Enum;

namespace lasertech_backend.Model;

public class PlayerSession
{
    [Key] public int PlayerSessionID { get; set; }

    [ForeignKey("Game")] public int GameID { get; set; }
    private Game Game { get; set; }

    [ForeignKey("Player")] public int PlayerID { get; set; }

    private Player Player { get; set; }
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

    public PlayerSession(PlayerSessionDTO p)
    {
        GameID = p.GameID;
        PlayerID = p.PlayerID;
        Team = p.Team;
        PlayerScore = 0;
        EquipmentID = p.EquipmentID;
    }
}