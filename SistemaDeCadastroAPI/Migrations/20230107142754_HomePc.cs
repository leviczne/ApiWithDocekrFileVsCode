using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeCadastroAPI.Migrations
{
    public partial class HomePc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NomeViagem",
                table: "Viagem",
                type: "nchar(100)",
                fixedLength: true,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "ntext");

            migrationBuilder.AddColumn<int>(
                name: "Id_Usuarios",
                table: "Viagem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Viagem_Id_Usuarios",
                table: "Viagem",
                column: "Id_Usuarios");

            migrationBuilder.AddForeignKey(
                name: "fk_usuarios",
                table: "Viagem",
                column: "Id_Usuarios",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_usuarios",
                table: "Viagem");

            migrationBuilder.DropIndex(
                name: "IX_Viagem_Id_Usuarios",
                table: "Viagem");

            migrationBuilder.DropColumn(
                name: "Id_Usuarios",
                table: "Viagem");

            migrationBuilder.AlterColumn<string>(
                name: "NomeViagem",
                table: "Viagem",
                type: "ntext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(100)",
                oldFixedLength: true,
                oldMaxLength: 100);
        }
    }
}
