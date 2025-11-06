using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestEducation.DataAcces.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TestUserTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Test_Subjects_SubjectId",
                table: "Test");

            migrationBuilder.DropForeignKey(
                name: "FK_UserQuestions_UserTest_UserTestId",
                table: "UserQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTest_Test_TestId",
                table: "UserTest");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTest_Users_UserId",
                table: "UserTest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTest",
                table: "UserTest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Test",
                table: "Test");

            migrationBuilder.RenameTable(
                name: "UserTest",
                newName: "userTests");

            migrationBuilder.RenameTable(
                name: "Test",
                newName: "tests");

            migrationBuilder.RenameIndex(
                name: "IX_UserTest_UserId",
                table: "userTests",
                newName: "IX_userTests_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTest_TestId",
                table: "userTests",
                newName: "IX_userTests_TestId");

            migrationBuilder.RenameIndex(
                name: "IX_Test_SubjectId",
                table: "tests",
                newName: "IX_tests_SubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userTests",
                table: "userTests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tests",
                table: "tests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tests_Subjects_SubjectId",
                table: "tests",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuestions_userTests_UserTestId",
                table: "UserQuestions",
                column: "UserTestId",
                principalTable: "userTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userTests_Users_UserId",
                table: "userTests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userTests_tests_TestId",
                table: "userTests",
                column: "TestId",
                principalTable: "tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tests_Subjects_SubjectId",
                table: "tests");

            migrationBuilder.DropForeignKey(
                name: "FK_UserQuestions_userTests_UserTestId",
                table: "UserQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_userTests_Users_UserId",
                table: "userTests");

            migrationBuilder.DropForeignKey(
                name: "FK_userTests_tests_TestId",
                table: "userTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userTests",
                table: "userTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tests",
                table: "tests");

            migrationBuilder.RenameTable(
                name: "userTests",
                newName: "UserTest");

            migrationBuilder.RenameTable(
                name: "tests",
                newName: "Test");

            migrationBuilder.RenameIndex(
                name: "IX_userTests_UserId",
                table: "UserTest",
                newName: "IX_UserTest_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_userTests_TestId",
                table: "UserTest",
                newName: "IX_UserTest_TestId");

            migrationBuilder.RenameIndex(
                name: "IX_tests_SubjectId",
                table: "Test",
                newName: "IX_Test_SubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTest",
                table: "UserTest",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Test",
                table: "Test",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Test_Subjects_SubjectId",
                table: "Test",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuestions_UserTest_UserTestId",
                table: "UserQuestions",
                column: "UserTestId",
                principalTable: "UserTest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTest_Test_TestId",
                table: "UserTest",
                column: "TestId",
                principalTable: "Test",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTest_Users_UserId",
                table: "UserTest",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
