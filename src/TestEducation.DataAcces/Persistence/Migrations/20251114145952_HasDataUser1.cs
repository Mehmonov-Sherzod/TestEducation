using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestEducation.DataAcces.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class HasDataUser1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Count", "CreatedAt", "Email", "ExpiredAt", "FullName", "IsActive", "IsVerified", "Password", "PhoneNumber", "Salt" },
                values: new object[] { 1, 0, new DateTime(2025, 11, 14, 14, 31, 0, 0, DateTimeKind.Utc), "mehmovovsherzod@gmail.com", null, "Sherzod", true, false, "XeASJOgK7h7Lk0XkPOlOq0LfqTu9bA93NrmMHnm3/mY=", "+998901537776", "8a68becd-d900-4835-b809-d728ac097656" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
