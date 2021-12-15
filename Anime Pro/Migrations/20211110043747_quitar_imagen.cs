using Microsoft.EntityFrameworkCore.Migrations;

namespace Anime_Pro.Migrations
{
    public partial class quitar_imagen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageYrl",
                table: "Estudios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageYrl",
                table: "Estudios",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
