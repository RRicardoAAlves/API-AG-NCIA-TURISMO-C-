using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myProject.Migrations
{
    public partial class Atualizar1Created : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_agencia",
                table: "agencia");

            migrationBuilder.RenameTable(
                name: "agencia",
                newName: "usuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuario",
                table: "usuario",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_usuario",
                table: "usuario");

            migrationBuilder.RenameTable(
                name: "usuario",
                newName: "agencia");

            migrationBuilder.AddPrimaryKey(
                name: "PK_agencia",
                table: "agencia",
                column: "id");
        }
    }
}
