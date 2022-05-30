using Microsoft.EntityFrameworkCore.Migrations;

namespace ChallengeAlkemy.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_generos_peliculas_Peliculaid",
                table: "generos");

            migrationBuilder.DropForeignKey(
                name: "FK_personajes_peliculas_peliculaId",
                table: "personajes");

            migrationBuilder.DropIndex(
                name: "IX_personajes_peliculaId",
                table: "personajes");

            migrationBuilder.DropIndex(
                name: "IX_generos_Peliculaid",
                table: "generos");

            migrationBuilder.DropColumn(
                name: "personajeId",
                table: "peliculas");

            migrationBuilder.DropColumn(
                name: "Peliculaid",
                table: "generos");

            migrationBuilder.AddColumn<int>(
                name: "generoId",
                table: "peliculas",
                type: "int",
                nullable: true);

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
                name: "IX_peliculas_generoId",
                table: "peliculas",
                column: "generoId");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaPersonaje_Personajesid",
                table: "PeliculaPersonaje",
                column: "Personajesid");

            migrationBuilder.AddForeignKey(
                name: "FK_peliculas_generos_generoId",
                table: "peliculas",
                column: "generoId",
                principalTable: "generos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_peliculas_generos_generoId",
                table: "peliculas");

            migrationBuilder.DropTable(
                name: "PeliculaPersonaje");

            migrationBuilder.DropIndex(
                name: "IX_peliculas_generoId",
                table: "peliculas");

            migrationBuilder.DropColumn(
                name: "generoId",
                table: "peliculas");

            migrationBuilder.AddColumn<int>(
                name: "personajeId",
                table: "peliculas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Peliculaid",
                table: "generos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_personajes_peliculaId",
                table: "personajes",
                column: "peliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_generos_Peliculaid",
                table: "generos",
                column: "Peliculaid");

            migrationBuilder.AddForeignKey(
                name: "FK_generos_peliculas_Peliculaid",
                table: "generos",
                column: "Peliculaid",
                principalTable: "peliculas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_personajes_peliculas_peliculaId",
                table: "personajes",
                column: "peliculaId",
                principalTable: "peliculas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
