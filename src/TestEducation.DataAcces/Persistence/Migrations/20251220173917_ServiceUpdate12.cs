using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestEducation.DataAcces.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ServiceUpdate12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TserBalances_Users_UserId",
                table: "TserBalances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TserBalances",
                table: "TserBalances");

            migrationBuilder.RenameTable(
                name: "TserBalances",
                newName: "UserBalances");

            migrationBuilder.RenameIndex(
                name: "IX_TserBalances_UserId",
                table: "UserBalances",
                newName: "IX_UserBalances_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBalances",
                table: "UserBalances",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBalances_Users_UserId",
                table: "UserBalances",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBalances_Users_UserId",
                table: "UserBalances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBalances",
                table: "UserBalances");

            migrationBuilder.RenameTable(
                name: "UserBalances",
                newName: "TserBalances");

            migrationBuilder.RenameIndex(
                name: "IX_UserBalances_UserId",
                table: "TserBalances",
                newName: "IX_TserBalances_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TserBalances",
                table: "TserBalances",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TserBalances_Users_UserId",
                table: "TserBalances",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
