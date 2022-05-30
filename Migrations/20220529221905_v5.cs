using Microsoft.EntityFrameworkCore.Migrations;

namespace ChallengeAlkemy.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeliculaPersonaje");

            migrationBuilder.CreateIndex(
                name: "IX_personajes_peliculaId",
                table: "personajes",
                column: "peliculaId");

            migrationBuilder.AddForeignKey(
                name: "FK_personajes_peliculas_peliculaId",
                table: "personajes",
                column: "peliculaId",
                principalTable: "peliculas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_personajes_peliculas_peliculaId",
                table: "personajes");

            migrationBuilder.DropIndex(
                name: "IX_personajes_peliculaId",
                table: "personajes");

            migrationBuilder.CreateTable(
                name: "PeliculaPersonaje",
                columns: table => new
                {
                    Peliculasid = table.Column<int>(type: "int", nullable: false),
                    Personajesid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculaPersonaje", x => new { x.Peliculasid, x.Personajesid });
                    table.ForeignKey(
                        name: "FK_PeliculaPersonaje_peliculas_Peliculasid",
                        column: x => x.Peliculasid,
                        principalTable: "peliculas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeliculaPersonaje_personajes_Personajesid",
                        column: x => x.Personajesid,
                        principalTable: "personajes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaPersonaje_Personajesid",
                table: "PeliculaPersonaje",
                column: "Personajesid");
        }
    }
}
