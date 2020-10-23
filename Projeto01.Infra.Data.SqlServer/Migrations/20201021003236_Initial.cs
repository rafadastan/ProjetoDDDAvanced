using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto01.Infra.Data.SqlServer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RazaoSocial = table.Column<string>(maxLength: 150, nullable: false),
                    NomeFantasia = table.Column<string>(maxLength: 150, nullable: false),
                    Cnpj = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 150, nullable: false),
                    Sexo = table.Column<int>(nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    Cpf = table.Column<string>(maxLength: 11, nullable: false),
                    DataAdmissao = table.Column<DateTime>(type: "date", nullable: false),
                    Situacao = table.Column<int>(nullable: false),
                    EmpresaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionario_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_Cnpj",
                table: "Empresa",
                column: "Cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_RazaoSocial",
                table: "Empresa",
                column: "RazaoSocial",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_Cpf",
                table: "Funcionario",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_EmpresaId",
                table: "Funcionario",
                column: "EmpresaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
