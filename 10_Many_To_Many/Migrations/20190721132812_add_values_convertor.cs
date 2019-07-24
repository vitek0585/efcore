using Microsoft.EntityFrameworkCore.Migrations;

namespace _00_Core.Migrations
{
    public partial class add_values_convertor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CardCode",
                table: "Players",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Players",
                nullable: false,
                defaultValue: "CF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardCode",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Players");
        }
    }
}
