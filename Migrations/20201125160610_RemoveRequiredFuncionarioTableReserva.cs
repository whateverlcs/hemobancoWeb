using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoHemobancoWeb.Migrations
{
    public partial class RemoveRequiredFuncionarioTableReserva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Funcionario_FuncionarioId",
                table: "Reserva");

            migrationBuilder.AlterColumn<int>(
                name: "FuncionarioId",
                table: "Reserva",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Funcionario_FuncionarioId",
                table: "Reserva",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Funcionario_FuncionarioId",
                table: "Reserva");

            migrationBuilder.AlterColumn<int>(
                name: "FuncionarioId",
                table: "Reserva",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Funcionario_FuncionarioId",
                table: "Reserva",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
