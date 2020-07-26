using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Domain.Data.Migrations
{
    public partial class change_conta_and_lancamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataLancamento",
                table: "Lancamentos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "Lancamentos",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "NumAgencia",
                table: "Contas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumConta",
                table: "Contas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataLancamento",
                table: "Lancamentos");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Lancamentos");

            migrationBuilder.DropColumn(
                name: "NumAgencia",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "NumConta",
                table: "Contas");
        }
    }
}
