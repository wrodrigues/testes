using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Domain.Data.Migrations
{
    public partial class rel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lancamentos_Contas_ContaCorrenteId",
                table: "Lancamentos");

            migrationBuilder.AlterColumn<int>(
                name: "ContaCorrenteId",
                table: "Lancamentos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamentos_Contas_ContaCorrenteId",
                table: "Lancamentos",
                column: "ContaCorrenteId",
                principalTable: "Contas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lancamentos_Contas_ContaCorrenteId",
                table: "Lancamentos");

            migrationBuilder.AlterColumn<int>(
                name: "ContaCorrenteId",
                table: "Lancamentos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamentos_Contas_ContaCorrenteId",
                table: "Lancamentos",
                column: "ContaCorrenteId",
                principalTable: "Contas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
