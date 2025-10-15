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
                table: "Question",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_question_SubjectId",
                table: "Question",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_question_subjects_SubjectId",
                table: "Question",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_question_subjects_SubjectId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_question_SubjectId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Question");
        }
    }
}
