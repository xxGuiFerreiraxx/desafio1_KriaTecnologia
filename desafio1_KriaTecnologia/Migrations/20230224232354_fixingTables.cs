using Microsoft.EntityFrameworkCore.Migrations;

namespace desafio1_KriaTecnologia.Migrations
{
    public partial class fixingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "idLinguagens",
                table: "tb_linguagens",
                newName: "nomeLinguagens");

            migrationBuilder.RenameColumn(
                name: "idDonoRepositorio",
                table: "tb_DonoRepositorio",
                newName: "nomeDonoRepositorio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nomeLinguagens",
                table: "tb_linguagens",
                newName: "idLinguagens");

            migrationBuilder.RenameColumn(
                name: "nomeDonoRepositorio",
                table: "tb_DonoRepositorio",
                newName: "idDonoRepositorio");
        }
    }
}
