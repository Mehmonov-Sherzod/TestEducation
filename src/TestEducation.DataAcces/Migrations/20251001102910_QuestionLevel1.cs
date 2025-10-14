using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestEducation.Migrations
{
    /// <inheritdoc />
    public partial class QuestionLevel1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_question_QuestionLevel_QuestionLevelId",
                table: "question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionLevel",
                table: "QuestionLevel");

            migrationBuilder.RenameTable(
                name: "QuestionLevel",
                newName: "questionLevel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_questionLevel",
                table: "questionLevel",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_questionLevel_Level",
                table: "questionLevel",
                column: "Level",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_question_questionLevel_QuestionLevelId",
                table: "question",
                column: "QuestionLevelId",
                principalTable: "questionLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_question_questionLevel_QuestionLevelId",
                table: "question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_questionLevel",
                table: "questionLevel");

            migrationBuilder.DropIndex(
                name: "IX_questionLevel_Level",
                table: "questionLevel");

            migrationBuilder.RenameTable(
                name: "questionLevel",
                newName: "QuestionLevel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionLevel",
                table: "QuestionLevel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_question_QuestionLevel_QuestionLevelId",
                table: "question",
                column: "QuestionLevelId",
                principalTable: "QuestionLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
