using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestEducation.DataAcces.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ServiceUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_topics_TopicId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_questionTranslations_Question_QuestionId",
                table: "questionTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_sharedSources_Subjects_SubjectId",
                table: "sharedSources");

            migrationBuilder.DropForeignKey(
                name: "FK_subjectTranslates_Subjects_SubjectId",
                table: "subjectTranslates");

            migrationBuilder.DropForeignKey(
                name: "FK_TestProcessUser_testProcesses_TestProcessesId",
                table: "TestProcessUser");

            migrationBuilder.DropForeignKey(
                name: "FK_topics_Subjects_SubjectId",
                table: "topics");

            migrationBuilder.DropForeignKey(
                name: "FK_userOTPs_Users_UserId",
                table: "userOTPs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserQuestions_testProcesses_TestProcessId",
                table: "UserQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userOTPs",
                table: "userOTPs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_topics",
                table: "topics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_testProcesses",
                table: "testProcesses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_subjectTranslates",
                table: "subjectTranslates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sharedSources",
                table: "sharedSources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_questionTranslations",
                table: "questionTranslations");

            migrationBuilder.RenameTable(
                name: "userOTPs",
                newName: "UserOTPs");

            migrationBuilder.RenameTable(
                name: "topics",
                newName: "Topics");

            migrationBuilder.RenameTable(
                name: "testProcesses",
                newName: "TestProcesses");

            migrationBuilder.RenameTable(
                name: "subjectTranslates",
                newName: "SubjectTranslates");

            migrationBuilder.RenameTable(
                name: "sharedSources",
                newName: "SharedSources");

            migrationBuilder.RenameTable(
                name: "questionTranslations",
                newName: "QuestionTranslations");

            migrationBuilder.RenameIndex(
                name: "IX_userOTPs_UserId",
                table: "UserOTPs",
                newName: "IX_UserOTPs_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_topics_SubjectId",
                table: "Topics",
                newName: "IX_Topics_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_subjectTranslates_SubjectId",
                table: "SubjectTranslates",
                newName: "IX_SubjectTranslates_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_sharedSources_SubjectId",
                table: "SharedSources",
                newName: "IX_SharedSources_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_questionTranslations_QuestionId",
                table: "QuestionTranslations",
                newName: "IX_QuestionTranslations_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserOTPs",
                table: "UserOTPs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topics",
                table: "Topics",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestProcesses",
                table: "TestProcesses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectTranslates",
                table: "SubjectTranslates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SharedSources",
                table: "SharedSources",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionTranslations",
                table: "QuestionTranslations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TserBalances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Amout = table.Column<decimal>(type: "numeric", nullable: false),
                    BalanceCode = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TserBalances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TserBalances_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TserBalances_UserId",
                table: "TserBalances",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Topics_TopicId",
                table: "Question",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionTranslations_Question_QuestionId",
                table: "QuestionTranslations",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SharedSources_Subjects_SubjectId",
                table: "SharedSources",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTranslates_Subjects_SubjectId",
                table: "SubjectTranslates",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestProcessUser_TestProcesses_TestProcessesId",
                table: "TestProcessUser",
                column: "TestProcessesId",
                principalTable: "TestProcesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Subjects_SubjectId",
                table: "Topics",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOTPs_Users_UserId",
                table: "UserOTPs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuestions_TestProcesses_TestProcessId",
                table: "UserQuestions",
                column: "TestProcessId",
                principalTable: "TestProcesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Topics_TopicId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionTranslations_Question_QuestionId",
                table: "QuestionTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_SharedSources_Subjects_SubjectId",
                table: "SharedSources");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTranslates_Subjects_SubjectId",
                table: "SubjectTranslates");

            migrationBuilder.DropForeignKey(
                name: "FK_TestProcessUser_TestProcesses_TestProcessesId",
                table: "TestProcessUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Subjects_SubjectId",
                table: "Topics");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOTPs_Users_UserId",
                table: "UserOTPs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserQuestions_TestProcesses_TestProcessId",
                table: "UserQuestions");

            migrationBuilder.DropTable(
                name: "TserBalances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserOTPs",
                table: "UserOTPs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topics",
                table: "Topics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestProcesses",
                table: "TestProcesses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectTranslates",
                table: "SubjectTranslates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SharedSources",
                table: "SharedSources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionTranslations",
                table: "QuestionTranslations");

            migrationBuilder.RenameTable(
                name: "UserOTPs",
                newName: "userOTPs");

            migrationBuilder.RenameTable(
                name: "Topics",
                newName: "topics");

            migrationBuilder.RenameTable(
                name: "TestProcesses",
                newName: "testProcesses");

            migrationBuilder.RenameTable(
                name: "SubjectTranslates",
                newName: "subjectTranslates");

            migrationBuilder.RenameTable(
                name: "SharedSources",
                newName: "sharedSources");

            migrationBuilder.RenameTable(
                name: "QuestionTranslations",
                newName: "questionTranslations");

            migrationBuilder.RenameIndex(
                name: "IX_UserOTPs_UserId",
                table: "userOTPs",
                newName: "IX_userOTPs_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Topics_SubjectId",
                table: "topics",
                newName: "IX_topics_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectTranslates_SubjectId",
                table: "subjectTranslates",
                newName: "IX_subjectTranslates_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_SharedSources_SubjectId",
                table: "sharedSources",
                newName: "IX_sharedSources_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionTranslations_QuestionId",
                table: "questionTranslations",
                newName: "IX_questionTranslations_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userOTPs",
                table: "userOTPs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_topics",
                table: "topics",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_testProcesses",
                table: "testProcesses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_subjectTranslates",
                table: "subjectTranslates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sharedSources",
                table: "sharedSources",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_questionTranslations",
                table: "questionTranslations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_topics_TopicId",
                table: "Question",
                column: "TopicId",
                principalTable: "topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_questionTranslations_Question_QuestionId",
                table: "questionTranslations",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sharedSources_Subjects_SubjectId",
                table: "sharedSources",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_subjectTranslates_Subjects_SubjectId",
                table: "subjectTranslates",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestProcessUser_testProcesses_TestProcessesId",
                table: "TestProcessUser",
                column: "TestProcessesId",
                principalTable: "testProcesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_topics_Subjects_SubjectId",
                table: "topics",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userOTPs_Users_UserId",
                table: "userOTPs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuestions_testProcesses_TestProcessId",
                table: "UserQuestions",
                column: "TestProcessId",
                principalTable: "testProcesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
