using Microsoft.EntityFrameworkCore.Migrations;

namespace ChallengeAlkemy.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_peliculas_peliculas_Peliculaid",
                table: "peliculas");

            migrationBuilder.DropIndex(
                name: "IX_peliculas_Peliculaid",
                table: "peliculas");

            migrationBuilder.DropColumn(
                name: "Peliculaid",
                table: "peliculas");

            migrationBuilder.AddColumn<int>(
                name: "Peliculaid",
                table: "generos",
                type: "int",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_generos_peliculas_Peliculaid",
                table: "generos");

            migrationBuilder.DropIndex(
                name: "IX_generos_Peliculaid",
                table: "generos");

            migrationBuilder.DropColumn(
                name: "Peliculaid",
                table: "generos");

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
        }
    }
}
