using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TestEducation.Migrations
{
    /// <inheritdoc />
    public partial class QuestionLevelEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_question_questionLevel_QuestionLevelId",
                table: "question");

            migrationBuilder.DropTable(
                name: "questionLevel");

            migrationBuilder.DropIndex(
                name: "IX_question_QuestionLevelId",
                table: "question");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "question",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "question");

            migrationBuilder.CreateTable(
                name: "questionLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Level = table.Column<string>(type: "text", nullable: false),
                    Point = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questionLevel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_question_QuestionLevelId",
                table: "question",
                column: "QuestionLevelId");

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
    }
}
