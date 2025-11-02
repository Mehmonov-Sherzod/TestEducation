using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TestEducation.DataAcces.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UserOtp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "userOTPs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpiredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserOTPsId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userOTPs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userOTPs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userOTPs_userOTPs_UserOTPsId",
                        column: x => x.UserOTPsId,
                        principalTable: "userOTPs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_userOTPs_UserId",
                table: "userOTPs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_userOTPs_UserOTPsId",
                table: "userOTPs",
                column: "UserOTPsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userOTPs");
        }
    }
}
