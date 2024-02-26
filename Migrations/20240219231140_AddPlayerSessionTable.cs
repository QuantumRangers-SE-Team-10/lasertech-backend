using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace lasertech_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddPlayerSessionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "playerSessions",
                columns: table => new
                {
                    PlayerSessionID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GameID = table.Column<int>(type: "integer", nullable: false),
                    PlayerID = table.Column<int>(type: "integer", nullable: false),
                    PlayerScore = table.Column<int>(type: "integer", nullable: false),
                    Team = table.Column<int>(type: "integer", nullable: false),
                    EquipmentID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playerSessions", x => x.PlayerSessionID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "playerSessions");
        }
    }
}
