using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoHemobancoWeb.Migrations
{
    public partial class CriarBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doador",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Cpf = table.Column<string>(nullable: false),
                    Idade = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Endereco = table.Column<string>(nullable: false),
                    Telefone = table.Column<string>(nullable: false),
                    Celular = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Cpf = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sangue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    TipoSangue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sangue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    TipoSangue = table.Column<string>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    FuncionarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reserva_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    DoadorId = table.Column<int>(nullable: false),
                    QuantidadeSangue = table.Column<int>(nullable: false),
                    SangueId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doacao_Doador_DoadorId",
                        column: x => x.DoadorId,
                        principalTable: "Doador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doacao_Sangue_SangueId",
                        column: x => x.SangueId,
                        principalTable: "Sangue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estoque",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    SangueId = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    UnidadeMedida = table.Column<string>(nullable: false),
                    FuncionarioId = table.Column<int>(nullable: false),
                    QuantidadeLitros = table.Column<float>(nullable: false),
                    AlteradoEm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estoque_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estoque_Sangue_SangueId",
                        column: x => x.SangueId,
                        principalTable: "Sangue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doacao_DoadorId",
                table: "Doacao",
                column: "DoadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Doacao_SangueId",
                table: "Doacao",
                column: "SangueId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_FuncionarioId",
                table: "Estoque",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_SangueId",
                table: "Estoque",
                column: "SangueId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_FuncionarioId",
                table: "Reserva",
                column: "FuncionarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doacao");

            migrationBuilder.DropTable(
                name: "Estoque");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Doador");

            migrationBuilder.DropTable(
                name: "Sangue");

            migrationBuilder.DropTable(
                name: "Funcionario");
        }
    }
}
