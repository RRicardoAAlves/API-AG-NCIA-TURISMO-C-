using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myProject.Migrations
{
    public partial class AtualizaAgencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "agencia");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "agencia",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "agencia",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "agencia",
                newName: "data_nascimento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_agencia",
                table: "agencia",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_agencia",
                table: "agencia");

            migrationBuilder.RenameTable(
                name: "agencia",
                newName: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Usuarios",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Usuarios",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "data_nascimento",
                table: "Usuarios",
                newName: "DataNascimento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");
        }
    }
}
