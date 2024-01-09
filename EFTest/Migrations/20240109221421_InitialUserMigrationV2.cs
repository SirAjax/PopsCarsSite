using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFTest.Migrations
{
    /// <inheritdoc />
    public partial class InitialUserMigrationV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Note",
                columns: new[] { "NoteId", "CarId", "Comments", "UserId" },
                values: new object[] { 1, 1, "this car should be a Chevy Biscayne", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Note",
                keyColumn: "NoteId",
                keyValue: 1);
        }
    }
}
