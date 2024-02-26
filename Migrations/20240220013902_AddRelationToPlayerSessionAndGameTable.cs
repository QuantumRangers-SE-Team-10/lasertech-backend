using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lasertech_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationToPlayerSessionAndGameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_playerSessions_GameID",
                table: "playerSessions",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_playerSessions_PlayerID",
                table: "playerSessions",
                column: "PlayerID");

            migrationBuilder.AddForeignKey(
                name: "FK_playerSessions_games_GameID",
                table: "playerSessions",
                column: "GameID",
                principalTable: "games",
                principalColumn: "GameID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_playerSessions_players_PlayerID",
                table: "playerSessions",
                column: "PlayerID",
                principalTable: "players",
                principalColumn: "PlayerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_playerSessions_games_GameID",
                table: "playerSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_playerSessions_players_PlayerID",
                table: "playerSessions");

            migrationBuilder.DropIndex(
                name: "IX_playerSessions_GameID",
                table: "playerSessions");

            migrationBuilder.DropIndex(
                name: "IX_playerSessions_PlayerID",
                table: "playerSessions");
        }
    }
}
