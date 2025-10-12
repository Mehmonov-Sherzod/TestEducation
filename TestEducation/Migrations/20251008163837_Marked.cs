using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestEducation.Migrations
{
    /// <inheritdoc />
    public partial class Marked : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAnswer",
                table: "userQuestions");

            migrationBuilder.DropColumn(
                name: "QuestionLevelId",
                table: "question");

            migrationBuilder.AddColumn<bool>(
                name: "IsMarked",
                table: "userQuestionsAnswer",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMarked",
                table: "userQuestionsAnswer");

            migrationBuilder.AddColumn<bool>(
                name: "IsAnswer",
                table: "userQuestions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "QuestionLevelId",
                table: "question",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
