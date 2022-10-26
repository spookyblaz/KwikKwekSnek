using Microsoft.EntityFrameworkCore.Migrations;

namespace KwikKwekSnek.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "drankjes",
                columns: table => new
                {
                    Naam = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    afbeelding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prijs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    grootte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ijs = table.Column<bool>(type: "bit", nullable: false),
                    plasticrietje = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drankjes", x => x.Naam);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "drankjes");
        }
    }
}
