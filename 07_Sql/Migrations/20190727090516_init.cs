using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _07_Sql.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    isEurope = table.Column<bool>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Countries", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    TeamId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] {"Id", "Name", "isEurope"},
                values: new object[] {1, "Ukraine", true});

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] {"Id", "Name", "isEurope"},
                values: new object[] {2, "Spain", true});

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] {"Id", "Name", "isEurope"},
                values: new object[] {3, "USA", false});

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] {"Id", "CountryId", "Name"},
                values: new object[] {1, 1, "Dynamo"});

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] {"Id", "CountryId", "Name"},
                values: new object[] {2, 1, "Shahtar"});

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] {"Id", "Name", "TeamId"},
                values: new object[] {1, "Rakitskiy", 1});

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] {"Id", "Name", "TeamId"},
                values: new object[] {2, "Milevskiy", 1});

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CountryId",
                table: "Teams",
                column: "CountryId");

            migrationBuilder.Sql(_insertTr);
            migrationBuilder.Sql(_tableFunc);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Countries");
        }

        private string _tableFunc = @"
                GO
                DROP FUNCTION If EXISTS GetTeams
                GO
                CREATE FUNCTION GetTeams()
                    RETURNS @teams TABLE
                    (
	                    Id int,
	                    Name nvarchar(100),
                        CountryId int
                    )
                BEGIN
                    INSERT INTO @teams
                    SELECT Id, Name, CountryId
                    FROM Teams
                    ORDER BY Name DESC
                    RETURN
                END
                GO";

        private string _insertTr = @"GO
            Create trigger [dbo].[TR_Country_InsteadOfInsert]
                on [UEFA2020].[dbo].[Countries]
            instead of insert
            as

            declare @tableIds table (Id int)
            declare @id int

            set @id = ident_current('[UEFA2020].[dbo].[Countries]')

            insert into Countries (Name, isEurope)
            output inserted.Id into @tableIds
            select 	
	            CONCAT(Name,' - Country'),
	            isEurope

            from 
	            inserted

            select 
	            Id
            from 
	            @tableIds
            ";
    }
}
