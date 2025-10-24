using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestEducation.DataAcces.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserQuestionsAnswer_Answers_AnswerId",
                table: "UserQuestionsAnswer");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserQuestionsAnswer_AnswerId",
                table: "UserQuestionsAnswer");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_Name",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "UserQuestionsAnswer");

            migrationBuilder.AddColumn<string>(
                name: "AnswerText",
                table: "UserQuestionsAnswer",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "UserQuestionsAnswer",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerText",
                table: "UserQuestionsAnswer");

            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "UserQuestionsAnswer");

            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "UserQuestionsAnswer",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserQuestionsAnswer_AnswerId",
                table: "UserQuestionsAnswer",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_Name",
                table: "Subjects",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuestionsAnswer_Answers_AnswerId",
                table: "UserQuestionsAnswer",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
