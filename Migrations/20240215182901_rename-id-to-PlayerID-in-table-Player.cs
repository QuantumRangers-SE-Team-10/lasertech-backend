using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lasertech_backend.Migrations
{
    /// <inheritdoc />
    public partial class renameidtoPlayerIDintablePlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "players",
                newName: "PlayerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlayerID",
                table: "players",
                newName: "Id");
        }
    }
}
