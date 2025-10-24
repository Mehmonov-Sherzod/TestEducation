using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TestEducation.DataAcces.Migrations
{
    /// <inheritdoc />
    public partial class Usertest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserTestId",
                table: "UserQuestions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "Question",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SubjectId = table.Column<int>(type: "integer", nullable: false),
                    DurationMinutes = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Test_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    TestId = table.Column<int>(type: "integer", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTest_Test_TestId",
                        column: x => x.TestId,
                        principalTable: "Test",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTest_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserQuestions_UserTestId",
                table: "UserQuestions",
                column: "UserTestId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_TestId",
                table: "Question",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_Test_SubjectId",
                table: "Test",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTest_TestId",
                table: "UserTest",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTest_UserId",
                table: "UserTest",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Test_TestId",
                table: "Question",
                column: "TestId",
                principalTable: "Test",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuestions_UserTest_UserTestId",
                table: "UserQuestions",
                column: "UserTestId",
                principalTable: "UserTest",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Test_TestId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_UserQuestions_UserTest_UserTestId",
                table: "UserQuestions");

            migrationBuilder.DropTable(
                name: "UserTest");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropIndex(
                name: "IX_UserQuestions_UserTestId",
                table: "UserQuestions");

            migrationBuilder.DropIndex(
                name: "IX_Question_TestId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "UserTestId",
                table: "UserQuestions");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "Question");
        }
    }
}
