using Microsoft.EntityFrameworkCore.Migrations;

namespace Crud.Infrastruture.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Sobrenome = table.Column<string>(type: "varchar(200)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.RoleName, x.UserEmail });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleName",
                        column: x => x.RoleName,
                        principalTable: "Role",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Usuario_UserEmail",
                        column: x => x.UserEmail,
                        principalTable: "Usuario",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Role",
                column: "Name",
                value: "Master");

            migrationBuilder.InsertData(
                table: "Role",
                column: "Name",
                value: "ADM");

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Email", "Nome", "PasswordHash", "Sobrenome" },
                values: new object[] { "boechat.stephani@gmail.com", "Master", "pvZ2UDVoS7aQD+Hx+Z9uuJBEXKJjKt/2aBI7cT6a6v0=", "tecnico" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleName", "UserEmail" },
                values: new object[] { "Master", "boechat.stephani@gmail.com" });

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserEmail",
                table: "UserRole",
                column: "UserEmail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
