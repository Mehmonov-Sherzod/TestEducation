using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestEducation.Migrations
{
    /// <inheritdoc />
    public partial class UrlImage12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Answers");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "question",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "question");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Answers",
                type: "text",
                nullable: true);
        }
    }
}
