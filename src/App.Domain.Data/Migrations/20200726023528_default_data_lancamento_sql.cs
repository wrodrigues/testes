using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Domain.Data.Migrations
{
    public partial class default_data_lancamento_sql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataLancamento",
                table: "Lancamentos",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 25, 23, 33, 53, 940, DateTimeKind.Local).AddTicks(6060));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataLancamento",
                table: "Lancamentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 25, 23, 33, 53, 940, DateTimeKind.Local).AddTicks(6060),
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getdate()");
        }
    }
}
