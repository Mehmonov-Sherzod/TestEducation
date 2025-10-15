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
                table: "UserQuestions");

            migrationBuilder.DropColumn(
                name: "QuestionLevelId",
                table: "Question");

            migrationBuilder.AddColumn<bool>(
                name: "IsMarked",
                table: "UserQuestionsAnswer",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMarked",
                table: "UserQuestionsAnswer");

            migrationBuilder.AddColumn<bool>(
                name: "IsAnswer",
                table: "UserQuestions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "QuestionLevelId",
                table: "Question",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
