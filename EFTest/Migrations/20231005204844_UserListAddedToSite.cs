using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFTest.Migrations
{
    /// <inheritdoc />
    public partial class UserListAddedToSite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "UserName" },
                values: new object[] { 1, "AJ" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
