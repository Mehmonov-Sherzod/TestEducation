using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestEducation.Migrations
{
    /// <inheritdoc />
    public partial class UserQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAnswer",
                table: "UserQuestions",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAnswer",
                table: "UserQuestions");
        }
    }
}
