using Microsoft.EntityFrameworkCore.Migrations;

namespace ChallengeAlkemy.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_peliculas_generos_generoId",
                table: "peliculas");

            migrationBuilder.DropForeignKey(
                name: "FK_personajes_peliculas_peliculaId",
                table: "personajes");

            migrationBuilder.RenameColumn(
                name: "peliculaId",
                table: "personajes",
                newName: "Peliculaid");

            migrationBuilder.RenameIndex(
                name: "IX_personajes_peliculaId",
                table: "personajes",
                newName: "IX_personajes_Peliculaid");

            migrationBuilder.RenameColumn(
                name: "generoId",
                table: "peliculas",
                newName: "Personajeid");

            migrationBuilder.RenameIndex(
                name: "IX_peliculas_generoId",
                table: "peliculas",
                newName: "IX_peliculas_Personajeid");

            migrationBuilder.AddColumn<int>(
                name: "Peliculaid",
                table: "peliculas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_peliculas_Peliculaid",
                table: "peliculas",
                column: "Peliculaid");

            migrationBuilder.AddForeignKey(
                name: "FK_peliculas_peliculas_Peliculaid",
                table: "peliculas",
                column: "Peliculaid",
                principalTable: "peliculas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_peliculas_personajes_Personajeid",
                table: "peliculas",
                column: "Personajeid",
                principalTable: "personajes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_personajes_peliculas_Peliculaid",
                table: "personajes",
                column: "Peliculaid",
                principalTable: "peliculas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_peliculas_peliculas_Peliculaid",
                table: "peliculas");

            migrationBuilder.DropForeignKey(
                name: "FK_peliculas_personajes_Personajeid",
                table: "peliculas");

            migrationBuilder.DropForeignKey(
                name: "FK_personajes_peliculas_Peliculaid",
                table: "personajes");

            migrationBuilder.DropIndex(
                name: "IX_peliculas_Peliculaid",
                table: "peliculas");

            migrationBuilder.DropColumn(
                name: "Peliculaid",
                table: "peliculas");

            migrationBuilder.RenameColumn(
                name: "Peliculaid",
                table: "personajes",
                newName: "peliculaId");

            migrationBuilder.RenameIndex(
                name: "IX_personajes_Peliculaid",
                table: "personajes",
                newName: "IX_personajes_peliculaId");

            migrationBuilder.RenameColumn(
                name: "Personajeid",
                table: "peliculas",
                newName: "generoId");

            migrationBuilder.RenameIndex(
                name: "IX_peliculas_Personajeid",
                table: "peliculas",
                newName: "IX_peliculas_generoId");

            migrationBuilder.AddForeignKey(
                name: "FK_peliculas_generos_generoId",
                table: "peliculas",
                column: "generoId",
                principalTable: "generos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_personajes_peliculas_peliculaId",
                table: "personajes",
                column: "peliculaId",
                principalTable: "peliculas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
