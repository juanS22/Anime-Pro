using Microsoft.EntityFrameworkCore.Migrations;

namespace Anime_Pro.Migrations
{
    public partial class series_tabla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagenUrl",
                table: "Estudios");

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Anio = table.Column<int>(type: "int", nullable: false),
                    Sinopsis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trailer = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    AficheUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstudioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Series_Estudios_EstudioId",
                        column: x => x.EstudioId,
                        principalTable: "Estudios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeriesGeneros",
                columns: table => new
                {
                    SerieId = table.Column<int>(type: "int", nullable: false),
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesGeneros", x => new { x.SerieId, x.GeneroId });
                    table.ForeignKey(
                        name: "FK_SeriesGeneros_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeriesGeneros_Series_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeriesPersonajes",
                columns: table => new
                {
                    PersonajeId = table.Column<int>(type: "int", nullable: false),
                    SerieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesPersonajes", x => new { x.PersonajeId, x.SerieId });
                    table.ForeignKey(
                        name: "FK_SeriesPersonajes_Personajes_PersonajeId",
                        column: x => x.PersonajeId,
                        principalTable: "Personajes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeriesPersonajes_Series_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Series_EstudioId",
                table: "Series",
                column: "EstudioId");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesGeneros_GeneroId",
                table: "SeriesGeneros",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesPersonajes_SerieId",
                table: "SeriesPersonajes",
                column: "SerieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeriesGeneros");

            migrationBuilder.DropTable(
                name: "SeriesPersonajes");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.AddColumn<string>(
                name: "ImagenUrl",
                table: "Estudios",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
