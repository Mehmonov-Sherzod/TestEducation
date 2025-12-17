using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TestEducation.DataAcces.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ErrorUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserQuestions_userTests_UserTestId",
                table: "UserQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserQuestionsAnswer_Answers_AnswerId",
                table: "UserQuestionsAnswer");

            migrationBuilder.DropTable(
                name: "UserTestResult");

            migrationBuilder.DropTable(
                name: "userTests");

            migrationBuilder.DropTable(
                name: "tests");

            migrationBuilder.DropIndex(
                name: "IX_UserQuestionsAnswer_AnswerId",
                table: "UserQuestionsAnswer");

            migrationBuilder.DropIndex(
                name: "IX_UserQuestions_UserTestId",
                table: "UserQuestions");

            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "UserQuestionsAnswer");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "UserQuestionsAnswer");

            migrationBuilder.RenameColumn(
                name: "UserTestId",
                table: "UserQuestions",
                newName: "TextProcessId");

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

            migrationBuilder.AddColumn<int>(
                name: "TestProcessId",
                table: "UserQuestions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "testProcesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndsAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TotalQuestions = table.Column<int>(type: "integer", nullable: false),
                    CorrectAnswers = table.Column<int>(type: "integer", nullable: true),
                    IncorrectAnswers = table.Column<int>(type: "integer", nullable: true),
                    PercentageOfCorrectAnswers = table.Column<float>(type: "real", nullable: true),
                    TotalScore = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_testProcesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestProcessUser",
                columns: table => new
                {
                    TestProcessesId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestProcessUser", x => new { x.TestProcessesId, x.UserId });
                    table.ForeignKey(
                        name: "FK_TestProcessUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestProcessUser_testProcesses_TestProcessesId",
                        column: x => x.TestProcessesId,
                        principalTable: "testProcesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserQuestions_TestProcessId",
                table: "UserQuestions",
                column: "TestProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_TestProcessUser_UserId",
                table: "TestProcessUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuestions_testProcesses_TestProcessId",
                table: "UserQuestions",
                column: "TestProcessId",
                principalTable: "testProcesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserQuestions_testProcesses_TestProcessId",
                table: "UserQuestions");

            migrationBuilder.DropTable(
                name: "TestProcessUser");

            migrationBuilder.DropTable(
                name: "testProcesses");

            migrationBuilder.DropIndex(
                name: "IX_UserQuestions_TestProcessId",
                table: "UserQuestions");

            migrationBuilder.DropColumn(
                name: "AnswerText",
                table: "UserQuestionsAnswer");

            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "UserQuestionsAnswer");

            migrationBuilder.DropColumn(
                name: "TestProcessId",
                table: "UserQuestions");

            migrationBuilder.RenameColumn(
                name: "TextProcessId",
                table: "UserQuestions",
                newName: "UserTestId");

            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "UserQuestionsAnswer",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "UserQuestionsAnswer",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubjectId = table.Column<int>(type: "integer", nullable: false),
                    DurationMinutes = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tests_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTestResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubjectId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CorrectAnswers = table.Column<int>(type: "integer", nullable: false),
                    FinishedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Percentage = table.Column<double>(type: "double precision", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TimeTaken = table.Column<TimeSpan>(type: "interval", nullable: false),
                    TotalQuestions = table.Column<int>(type: "integer", nullable: false),
                    WrongAnswers = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTestResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTestResult_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTestResult_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TestId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StartedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userTests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userTests_tests_TestId",
                        column: x => x.TestId,
                        principalTable: "tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserQuestionsAnswer_AnswerId",
                table: "UserQuestionsAnswer",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserQuestions_UserTestId",
                table: "UserQuestions",
                column: "UserTestId");

            migrationBuilder.CreateIndex(
                name: "IX_tests_SubjectId",
                table: "tests",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTestResult_SubjectId",
                table: "UserTestResult",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTestResult_UserId",
                table: "UserTestResult",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_userTests_TestId",
                table: "userTests",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_userTests_UserId",
                table: "userTests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuestions_userTests_UserTestId",
                table: "UserQuestions",
                column: "UserTestId",
                principalTable: "userTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
