using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class NomeUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeUsuario",
                schema: "cadastros",
                table: "Usuariuo",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeUsuario",
                schema: "cadastros",
                table: "Usuariuo");
        }
    }
}
