using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestEducation.DataAcces.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class yuuuvjj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserQuestions_TestProcesses_TestProcessId",
                table: "UserQuestions");

            migrationBuilder.AlterColumn<double>(
                name: "TotalScore",
                table: "TestProcesses",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<int>(
                name: "TotalQuestions",
                table: "TestProcesses",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuestions_TestProcesses_TestProcessId",
                table: "UserQuestions",
                column: "TestProcessId",
                principalTable: "TestProcesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserQuestions_TestProcesses_TestProcessId",
                table: "UserQuestions");

            migrationBuilder.AlterColumn<double>(
                name: "TotalScore",
                table: "TestProcesses",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "TotalQuestions",
                table: "TestProcesses",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuestions_TestProcesses_TestProcessId",
                table: "UserQuestions",
                column: "TestProcessId",
                principalTable: "TestProcesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
