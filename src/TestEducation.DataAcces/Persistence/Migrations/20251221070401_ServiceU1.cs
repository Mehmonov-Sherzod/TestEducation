using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestEducation.DataAcces.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ServiceU1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BalanceTransactions",
                columns: new[] { "Id", "CardNumber", "FullName", "UserAdmin" },
                values: new object[] { new Guid("11111118-1111-1111-1111-111111111119"), "9860 3401 0311 6182", "Mehmonov Sherzod", "@Sherzod_3466" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BalanceTransactions",
                keyColumn: "Id",
                keyValue: new Guid("11111118-1111-1111-1111-111111111119"));
        }
    }
}
