using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TestEducation.DataAcces.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TranslateQuestionAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionTranslation_Question_QuestionId",
                table: "QuestionTranslation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionTranslation",
                table: "QuestionTranslation");

            migrationBuilder.RenameTable(
                name: "QuestionTranslation",
                newName: "questionTranslations");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "subjectTranslates",
                newName: "Language");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionTranslation_QuestionId",
                table: "questionTranslations",
                newName: "IX_questionTranslations_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_questionTranslations",
                table: "questionTranslations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AnswerTranslate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnswerId = table.Column<int>(type: "integer", nullable: false),
                    LanguageId = table.Column<int>(type: "integer", nullable: false),
                    ColumnName = table.Column<string>(type: "text", nullable: false),
                    TranslateText = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerTranslate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerTranslate_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerTranslate_AnswerId",
                table: "AnswerTranslate",
                column: "AnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_questionTranslations_Question_QuestionId",
                table: "questionTranslations",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_questionTranslations_Question_QuestionId",
                table: "questionTranslations");

            migrationBuilder.DropTable(
                name: "AnswerTranslate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_questionTranslations",
                table: "questionTranslations");

            migrationBuilder.RenameTable(
                name: "questionTranslations",
                newName: "QuestionTranslation");

            migrationBuilder.RenameColumn(
                name: "Language",
                table: "subjectTranslates",
                newName: "LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_questionTranslations_QuestionId",
                table: "QuestionTranslation",
                newName: "IX_QuestionTranslation_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionTranslation",
                table: "QuestionTranslation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionTranslation_Question_QuestionId",
                table: "QuestionTranslation",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
