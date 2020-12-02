using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoHemobancoWeb.Migrations
{
    public partial class addCamposEnderecoTableDoador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Doador");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Doador",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Doador",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Localidade",
                table: "Doador",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Doador",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Uf",
                table: "Doador",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Doador");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Doador");

            migrationBuilder.DropColumn(
                name: "Localidade",
                table: "Doador");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Doador");

            migrationBuilder.DropColumn(
                name: "Uf",
                table: "Doador");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Doador",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
