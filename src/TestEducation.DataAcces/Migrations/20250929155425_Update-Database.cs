using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestEducation.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "question",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_question_SubjectId",
                table: "question",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_question_subjects_SubjectId",
                table: "question",
                column: "SubjectId",
                principalTable: "subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_question_subjects_SubjectId",
                table: "question");

            migrationBuilder.DropIndex(
                name: "IX_question_SubjectId",
                table: "question");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "question");
        }
    }
}
