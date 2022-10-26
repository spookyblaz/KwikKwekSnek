using Microsoft.EntityFrameworkCore.Migrations;

namespace KwikKwekSnek.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_drankjes",
                table: "drankjes");

            migrationBuilder.AlterColumn<string>(
                name: "Naam",
                table: "drankjes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "drankjes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_drankjes",
                table: "drankjes",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_drankjes",
                table: "drankjes");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "drankjes");

            migrationBuilder.AlterColumn<string>(
                name: "Naam",
                table: "drankjes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_drankjes",
                table: "drankjes",
                column: "Naam");
        }
    }
}
