using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestEducation.DataAcces.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ServiceUpdate12121 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserBalances",
                columns: new[] { "Id", "Amout", "BalanceCode", "UserId" },
                values: new object[] { new Guid("11111112-1111-1111-1111-111111111119"), 9999999999m, "675983410", new Guid("11111111-1111-1111-1111-111111111119") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserBalances",
                keyColumn: "Id",
                keyValue: new Guid("11111112-1111-1111-1111-111111111119"));
        }
    }
}
