using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestEducation.DataAcces.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class OtpUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userOTPs_userOTPs_UserOTPsId",
                table: "userOTPs");

            migrationBuilder.DropIndex(
                name: "IX_userOTPs_UserOTPsId",
                table: "userOTPs");

            migrationBuilder.DropColumn(
                name: "UserOTPsId",
                table: "userOTPs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserOTPsId",
                table: "userOTPs",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_userOTPs_UserOTPsId",
                table: "userOTPs",
                column: "UserOTPsId");

            migrationBuilder.AddForeignKey(
                name: "FK_userOTPs_userOTPs_UserOTPsId",
                table: "userOTPs",
                column: "UserOTPsId",
                principalTable: "userOTPs",
                principalColumn: "Id");
        }
    }
}
