using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestEducation.DataAcces.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _1234fds121 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuestionText",
                table: "UserQuestions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SubjectName",
                table: "UserQuestions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "SubjectId",
                table: "Question",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Question_SubjectId",
                table: "Question",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Subjects_SubjectId",
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
                name: "FK_Question_Subjects_SubjectId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_SubjectId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "QuestionText",
                table: "UserQuestions");

            migrationBuilder.DropColumn(
                name: "SubjectName",
                table: "UserQuestions");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Question");
        }
    }
}
