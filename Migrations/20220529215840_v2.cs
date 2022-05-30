using Microsoft.EntityFrameworkCore.Migrations;

namespace ChallengeAlkemy.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_peliculas_personajes_personajeid",
                table: "peliculas");

            migrationBuilder.DropForeignKey(
                name: "FK_personajes_peliculas_Peliculaid",
                table: "personajes");

            migrationBuilder.DropIndex(
                name: "IX_peliculas_personajeid",
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
                name: "personajeid",
                table: "peliculas",
                newName: "personajeId");

            migrationBuilder.AlterColumn<int>(
                name: "peliculaId",
                table: "personajes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "personajeId",
                table: "peliculas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_personajes_peliculas_peliculaId",
                table: "personajes",
                column: "peliculaId",
                principalTable: "peliculas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "personajeId",
                table: "peliculas",
                newName: "personajeid");

            migrationBuilder.AlterColumn<int>(
                name: "Peliculaid",
                table: "personajes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "personajeid",
                table: "peliculas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_peliculas_personajeid",
                table: "peliculas",
                column: "personajeid");

            migrationBuilder.AddForeignKey(
                name: "FK_peliculas_personajes_personajeid",
                table: "peliculas",
                column: "personajeid",
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
    }
}
