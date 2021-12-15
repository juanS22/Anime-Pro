using Microsoft.EntityFrameworkCore.Migrations;

namespace Anime_Pro.Migrations
{
    public partial class edicion_fecha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaLanzaminto",
                table: "Personajes",
                newName: "FechaLanzamiento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaLanzamiento",
                table: "Personajes",
                newName: "FechaLanzaminto");
        }
    }
}
