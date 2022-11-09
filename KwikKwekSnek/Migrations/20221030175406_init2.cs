using Microsoft.EntityFrameworkCore.Migrations;

namespace KwikKwekSnek.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "grootte",
                table: "drankjes");

            migrationBuilder.DropColumn(
                name: "ijs",
                table: "drankjes");

            migrationBuilder.DropColumn(
                name: "plasticrietje",
                table: "drankjes");

            migrationBuilder.CreateTable(
                name: "Bestelling",
                columns: table => new
                {
                    bestellingsnummer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    snacks = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestelling", x => x.bestellingsnummer);
                });

            migrationBuilder.CreateTable(
                name: "Extrasdrankje",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    grootte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ijs = table.Column<bool>(type: "bit", nullable: false),
                    plasticrietje = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extrasdrankje", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Drankjehasextra",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrankjeID = table.Column<int>(type: "int", nullable: true),
                    ExtrasdrankjeID = table.Column<int>(type: "int", nullable: true),
                    bestellingsnummer = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drankjehasextra", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Drankjehasextra_Bestelling_bestellingsnummer",
                        column: x => x.bestellingsnummer,
                        principalTable: "Bestelling",
                        principalColumn: "bestellingsnummer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Drankjehasextra_drankjes_DrankjeID",
                        column: x => x.DrankjeID,
                        principalTable: "drankjes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Drankjehasextra_Extrasdrankje_ExtrasdrankjeID",
                        column: x => x.ExtrasdrankjeID,
                        principalTable: "Extrasdrankje",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drankjehasextra_bestellingsnummer",
                table: "Drankjehasextra",
                column: "bestellingsnummer");

            migrationBuilder.CreateIndex(
                name: "IX_Drankjehasextra_DrankjeID",
                table: "Drankjehasextra",
                column: "DrankjeID");

            migrationBuilder.CreateIndex(
                name: "IX_Drankjehasextra_ExtrasdrankjeID",
                table: "Drankjehasextra",
                column: "ExtrasdrankjeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drankjehasextra");

            migrationBuilder.DropTable(
                name: "Bestelling");

            migrationBuilder.DropTable(
                name: "Extrasdrankje");

            migrationBuilder.AddColumn<string>(
                name: "grootte",
                table: "drankjes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ijs",
                table: "drankjes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "plasticrietje",
                table: "drankjes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
