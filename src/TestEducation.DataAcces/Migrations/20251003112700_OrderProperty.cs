using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestEducation.Migrations
{
    /// <inheritdoc />
    public partial class OrderProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "UserQuestionsAnswer",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "UserQuestions",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "UserQuestionsAnswer");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "UserQuestions");
        }
    }
}
