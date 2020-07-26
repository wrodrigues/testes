using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Domain.Data.Migrations
{
    public partial class createdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contas",
                columns: new[] { "Id", "NumAgencia", "NumConta" },
                values: new object[] { 1, "1010", "1010-1" });

            migrationBuilder.InsertData(
                table: "Contas",
                columns: new[] { "Id", "NumAgencia", "NumConta" },
                values: new object[] { 2, "2020", "2020-2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
