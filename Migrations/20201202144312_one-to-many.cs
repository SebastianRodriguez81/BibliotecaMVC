using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotecaMVC.Migrations
{
    public partial class onetomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    IDAutor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.IDAutor);
                });

            migrationBuilder.CreateTable(
                name: "Editoriales",
                columns: table => new
                {
                    IDEditorial = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editoriales", x => x.IDEditorial);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    IDGenero = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreGenero = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.IDGenero);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IDUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    DNI = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Contraseña = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IDUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    IDLibro = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(nullable: true),
                    IDAutor = table.Column<int>(nullable: false),
                    IDGenero = table.Column<int>(nullable: false),
                    IDEditorial = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.IDLibro);
                    table.ForeignKey(
                        name: "FK_Libros_Autores_IDAutor",
                        column: x => x.IDAutor,
                        principalTable: "Autores",
                        principalColumn: "IDAutor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libros_Editoriales_IDEditorial",
                        column: x => x.IDEditorial,
                        principalTable: "Editoriales",
                        principalColumn: "IDEditorial",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libros_Generos_IDGenero",
                        column: x => x.IDGenero,
                        principalTable: "Generos",
                        principalColumn: "IDGenero",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libros_IDAutor",
                table: "Libros",
                column: "IDAutor");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_IDEditorial",
                table: "Libros",
                column: "IDEditorial");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_IDGenero",
                table: "Libros",
                column: "IDGenero");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Editoriales");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}
