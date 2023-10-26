using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFTest.Migrations
{
    /// <inheritdoc />
    public partial class idchangesreverted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "User",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "NoteId",
                table: "Note",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "Car",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Note",
                newName: "NoteId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Car",
                newName: "CarId");
        }
    }
}
