using Microsoft.EntityFrameworkCore.Migrations;

namespace Crud.Infrastruture.Migrations
{
    public partial class correcaoOrtogr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnoDeFabricação",
                table: "Veiculos",
                newName: "AnoDeFabricacao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnoDeFabricacao",
                table: "Veiculos",
                newName: "AnoDeFabricação");
        }
    }
}
