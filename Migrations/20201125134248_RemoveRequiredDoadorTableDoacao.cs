using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoHemobancoWeb.Migrations
{
    public partial class RemoveRequiredDoadorTableDoacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doacao_Doador_DoadorId",
                table: "Doacao");

            migrationBuilder.AlterColumn<int>(
                name: "DoadorId",
                table: "Doacao",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Doacao_Doador_DoadorId",
                table: "Doacao",
                column: "DoadorId",
                principalTable: "Doador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doacao_Doador_DoadorId",
                table: "Doacao");

            migrationBuilder.AlterColumn<int>(
                name: "DoadorId",
                table: "Doacao",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Doacao_Doador_DoadorId",
                table: "Doacao",
                column: "DoadorId",
                principalTable: "Doador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
