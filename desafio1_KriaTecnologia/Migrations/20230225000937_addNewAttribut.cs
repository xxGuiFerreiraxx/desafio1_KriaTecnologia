using Microsoft.EntityFrameworkCore.Migrations;

namespace desafio1_KriaTecnologia.Migrations
{
    public partial class addNewAttribut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "descricao",
                table: "tb_Repositorios",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "descricao",
                table: "tb_Repositorios");
        }
    }
}
