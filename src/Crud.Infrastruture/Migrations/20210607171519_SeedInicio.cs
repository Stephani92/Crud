using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Crud.Infrastruture.Migrations
{
    public partial class SeedInicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Condutores",
                columns: table => new
                {
                    CPF = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condutores", x => x.CPF);
                });

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
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataDenascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Placa = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnoDeFabricação = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Placa);
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

            migrationBuilder.CreateTable(
                name: "VeiculoCondutores",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DataVenda = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VeiculoPlaca = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CondutorCpf = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeiculoCondutores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VeiculoCondutores_Condutores_CondutorCpf",
                        column: x => x.CondutorCpf,
                        principalTable: "Condutores",
                        principalColumn: "CPF",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VeiculoCondutores_Veiculos_VeiculoPlaca",
                        column: x => x.VeiculoPlaca,
                        principalTable: "Veiculos",
                        principalColumn: "Placa",
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
                columns: new[] { "Email", "Nome", "PasswordHash", "Sobrenome", "dataDenascimento" },
                values: new object[] { "master.tecnico@gmail.com", "Master", "pvZ2UDVoS7aQD+Hx+Z9uuJBEXKJjKt/2aBI7cT6a6v0=", "tecnico", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleName", "UserEmail" },
                values: new object[] { "Master", "master.tecnico@gmail.com" });

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserEmail",
                table: "UserRole",
                column: "UserEmail");

            migrationBuilder.CreateIndex(
                name: "IX_VeiculoCondutores_CondutorCpf",
                table: "VeiculoCondutores",
                column: "CondutorCpf");

            migrationBuilder.CreateIndex(
                name: "IX_VeiculoCondutores_VeiculoPlaca",
                table: "VeiculoCondutores",
                column: "VeiculoPlaca");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "VeiculoCondutores");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Condutores");

            migrationBuilder.DropTable(
                name: "Veiculos");
        }
    }
}
