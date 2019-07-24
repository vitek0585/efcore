using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _00_Core.Migrations
{
    public partial class add_many_to_many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FootballAward",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballAward", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerFootballAward",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false),
                    FootballAwardId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerFootballAward", x => new { x.PlayerId, x.FootballAwardId });
                    table.ForeignKey(
                        name: "FK_PlayerFootballAward_FootballAward_FootballAwardId",
                        column: x => x.FootballAwardId,
                        principalTable: "FootballAward",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerFootballAward_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FootballAward",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Golden Ball" });

            migrationBuilder.InsertData(
                table: "PlayerFootballAward",
                columns: new[] { "PlayerId", "FootballAwardId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerFootballAward_FootballAwardId",
                table: "PlayerFootballAward",
                column: "FootballAwardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerFootballAward");

            migrationBuilder.DropTable(
                name: "FootballAward");
        }
    }
}
