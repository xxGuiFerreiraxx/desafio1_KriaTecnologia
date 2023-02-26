using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace desafio1_KriaTecnologia.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_DonoRepositorio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idDonoRepositorio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_DonoRepositorio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_linguagens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idLinguagens = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_linguagens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Repositorios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeRepositorio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataUltimaAtt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idDonoRepositorio = table.Column<int>(type: "int", nullable: false),
                    idLinguagem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Repositorios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Repositorios_tb_DonoRepositorio_idDonoRepositorio",
                        column: x => x.idDonoRepositorio,
                        principalTable: "tb_DonoRepositorio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_Repositorios_tb_linguagens_idLinguagem",
                        column: x => x.idLinguagem,
                        principalTable: "tb_linguagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Repositorios_idDonoRepositorio",
                table: "tb_Repositorios",
                column: "idDonoRepositorio");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Repositorios_idLinguagem",
                table: "tb_Repositorios",
                column: "idLinguagem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Repositorios");

            migrationBuilder.DropTable(
                name: "tb_DonoRepositorio");

            migrationBuilder.DropTable(
                name: "tb_linguagens");
        }
    }
}
