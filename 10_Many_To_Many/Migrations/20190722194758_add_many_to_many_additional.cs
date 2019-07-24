using Microsoft.EntityFrameworkCore.Migrations;

namespace _00_Core.Migrations
{
    public partial class add_many_to_many_additional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PlayerFootballAward",
                columns: new[] { "PlayerId", "FootballAwardId" },
                values: new object[] { 2, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlayerFootballAward",
                keyColumns: new[] { "PlayerId", "FootballAwardId" },
                keyValues: new object[] { 2, 1 });
        }
    }
}
