using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFTest.Migrations
{
    /// <inheritdoc />
    public partial class correctingids : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_User_UserId",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_UserId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Car");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Car",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 6,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 7,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 8,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 9,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 10,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 11,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 12,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 13,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 14,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 15,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 16,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 17,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 18,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 19,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 20,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 21,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 22,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 23,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 24,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 25,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 26,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 27,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 28,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 29,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 30,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 31,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 32,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 33,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 34,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 35,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CarId",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Car_UserId",
                table: "Car",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_User_UserId",
                table: "Car",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
