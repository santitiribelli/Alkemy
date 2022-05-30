using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChallengeAlkemy.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "generos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Peliculaid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "personajes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    edad = table.Column<int>(type: "int", nullable: false),
                    imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    peso = table.Column<float>(type: "real", nullable: false),
                    historia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Peliculaid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personajes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "peliculas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    clasificacion = table.Column<int>(type: "int", nullable: false),
                    personajeid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_peliculas", x => x.id);
                    table.ForeignKey(
                        name: "FK_peliculas_personajes_personajeid",
                        column: x => x.personajeid,
                        principalTable: "personajes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_generos_Peliculaid",
                table: "generos",
                column: "Peliculaid");

            migrationBuilder.CreateIndex(
                name: "IX_peliculas_personajeid",
                table: "peliculas",
                column: "personajeid");

            migrationBuilder.CreateIndex(
                name: "IX_personajes_Peliculaid",
                table: "personajes",
                column: "Peliculaid");

            migrationBuilder.AddForeignKey(
                name: "FK_generos_peliculas_Peliculaid",
                table: "generos",
                column: "Peliculaid",
                principalTable: "peliculas",
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
                name: "FK_personajes_peliculas_Peliculaid",
                table: "personajes");

            migrationBuilder.DropTable(
                name: "generos");

            migrationBuilder.DropTable(
                name: "peliculas");

            migrationBuilder.DropTable(
                name: "personajes");
        }
    }
}
