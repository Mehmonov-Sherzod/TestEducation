using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestEducation.DataAcces.Migrations
{
    /// <inheritdoc />
    public partial class Usertest121 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserQuestions_UserTest_UserTestId",
                table: "UserQuestions");

            migrationBuilder.AlterColumn<int>(
                name: "UserTestId",
                table: "UserQuestions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AnsweredAt",
                table: "UserQuestions",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserQuestions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuestions_UserTest_UserTestId",
                table: "UserQuestions",
                column: "UserTestId",
                principalTable: "UserTest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserQuestions_UserTest_UserTestId",
                table: "UserQuestions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserQuestions");

            migrationBuilder.AlterColumn<int>(
                name: "UserTestId",
                table: "UserQuestions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AnsweredAt",
                table: "UserQuestions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuestions_UserTest_UserTestId",
                table: "UserQuestions",
                column: "UserTestId",
                principalTable: "UserTest",
                principalColumn: "Id");
        }
    }
}
