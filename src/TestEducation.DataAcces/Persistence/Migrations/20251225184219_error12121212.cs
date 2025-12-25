using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestEducation.DataAcces.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class error12121212 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestProcessUser");

            migrationBuilder.AddColumn<bool>(
                name: "IsFinished",
                table: "TestProcesses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_TestProcesses_UserId",
                table: "TestProcesses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestProcesses_Users_UserId",
                table: "TestProcesses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestProcesses_Users_UserId",
                table: "TestProcesses");

            migrationBuilder.DropIndex(
                name: "IX_TestProcesses_UserId",
                table: "TestProcesses");

            migrationBuilder.DropColumn(
                name: "IsFinished",
                table: "TestProcesses");

            migrationBuilder.CreateTable(
                name: "TestProcessUser",
                columns: table => new
                {
                    TestProcessesId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestProcessUser", x => new { x.TestProcessesId, x.UserId });
                    table.ForeignKey(
                        name: "FK_TestProcessUser_TestProcesses_TestProcessesId",
                        column: x => x.TestProcessesId,
                        principalTable: "TestProcesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestProcessUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestProcessUser_UserId",
                table: "TestProcessUser",
                column: "UserId");
        }
    }
}
