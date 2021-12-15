using Microsoft.EntityFrameworkCore.Migrations;

namespace Anime_Pro.Migrations
{
    public partial class edition_imagen2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Personajes",
                newName: "ImagenUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagenUrl",
                table: "Personajes",
                newName: "ImageUrl");
        }
    }
}
