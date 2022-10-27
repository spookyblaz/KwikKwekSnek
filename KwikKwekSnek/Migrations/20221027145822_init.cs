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
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    afbeelding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prijs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    grootte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ijs = table.Column<bool>(type: "bit", nullable: false),
                    plasticrietje = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drankjes", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "drankjes");
        }
    }
}
