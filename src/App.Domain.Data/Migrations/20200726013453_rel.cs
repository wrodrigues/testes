using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Domain.Data.Migrations
{
    public partial class rel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContaCorrenteId",
                table: "Lancamentos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_ContaCorrenteId",
                table: "Lancamentos",
                column: "ContaCorrenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamentos_Contas_ContaCorrenteId",
                table: "Lancamentos",
                column: "ContaCorrenteId",
                principalTable: "Contas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lancamentos_Contas_ContaCorrenteId",
                table: "Lancamentos");

            migrationBuilder.DropIndex(
                name: "IX_Lancamentos_ContaCorrenteId",
                table: "Lancamentos");

            migrationBuilder.DropColumn(
                name: "ContaCorrenteId",
                table: "Lancamentos");
        }
    }
}
