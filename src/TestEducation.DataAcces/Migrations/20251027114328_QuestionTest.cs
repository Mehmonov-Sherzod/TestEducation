using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestEducation.DataAcces.Migrations
{
    /// <inheritdoc />
    public partial class QuestionTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Test_TestId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_TestId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "Question");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "Question",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_TestId",
                table: "Question",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Test_TestId",
                table: "Question",
                column: "TestId",
                principalTable: "Test",
                principalColumn: "Id");
        }
    }
}
