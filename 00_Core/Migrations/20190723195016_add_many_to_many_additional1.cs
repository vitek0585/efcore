using Microsoft.EntityFrameworkCore.Migrations;

namespace _00_Core.Migrations
{
    public partial class add_many_to_many_additional1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerFootballAward_FootballAward_FootballAwardId",
                table: "PlayerFootballAward");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerFootballAward_Players_PlayerId",
                table: "PlayerFootballAward");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerFootballAward",
                table: "PlayerFootballAward");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FootballAward",
                table: "FootballAward");

            migrationBuilder.RenameTable(
                name: "PlayerFootballAward",
                newName: "PlayerFootballAwards");

            migrationBuilder.RenameTable(
                name: "FootballAward",
                newName: "FootballAwards");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerFootballAward_FootballAwardId",
                table: "PlayerFootballAwards",
                newName: "IX_PlayerFootballAwards_FootballAwardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerFootballAwards",
                table: "PlayerFootballAwards",
                columns: new[] { "PlayerId", "FootballAwardId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FootballAwards",
                table: "FootballAwards",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerFootballAwards_FootballAwards_FootballAwardId",
                table: "PlayerFootballAwards",
                column: "FootballAwardId",
                principalTable: "FootballAwards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerFootballAwards_Players_PlayerId",
                table: "PlayerFootballAwards",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerFootballAwards_FootballAwards_FootballAwardId",
                table: "PlayerFootballAwards");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerFootballAwards_Players_PlayerId",
                table: "PlayerFootballAwards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerFootballAwards",
                table: "PlayerFootballAwards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FootballAwards",
                table: "FootballAwards");

            migrationBuilder.RenameTable(
                name: "PlayerFootballAwards",
                newName: "PlayerFootballAward");

            migrationBuilder.RenameTable(
                name: "FootballAwards",
                newName: "FootballAward");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerFootballAwards_FootballAwardId",
                table: "PlayerFootballAward",
                newName: "IX_PlayerFootballAward_FootballAwardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerFootballAward",
                table: "PlayerFootballAward",
                columns: new[] { "PlayerId", "FootballAwardId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FootballAward",
                table: "FootballAward",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerFootballAward_FootballAward_FootballAwardId",
                table: "PlayerFootballAward",
                column: "FootballAwardId",
                principalTable: "FootballAward",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerFootballAward_Players_PlayerId",
                table: "PlayerFootballAward",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
