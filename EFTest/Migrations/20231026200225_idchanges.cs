using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFTest.Migrations
{
    /// <inheritdoc />
    public partial class idchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Car",
                table: "Car");

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "CarId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Note",
                newName: "NoteId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Car",
                newName: "UserId");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "User",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Car",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Car",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Car",
                table: "Car",
                column: "CarId");

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "CarId", "Color", "Make", "Model", "UserId", "Year" },
                values: new object[,]
                {
                    { 1, "Blue", "Chevy", "Biscayne", 0, 1968 },
                    { 2, "Blue", "Ford", "Fairlane", 0, 1967 },
                    { 3, "Turquoise Blue/Green", "Volkswagen", "Beetle", 0, 1965 },
                    { 4, "Green", "Chevy", "Impala", 0, 1966 },
                    { 5, "Green", "Ford", "Pinto", 0, 1972 },
                    { 6, "Beige", "Volkswagen", "Beetle", 0, 1964 },
                    { 7, "Beige", "Nissan", "Datsun", 0, 1967 },
                    { 8, "Maroon", "Ford", "Fairlane", 0, 1963 },
                    { 9, "Light Blue", "Dodge", "Monaco", 0, 1975 },
                    { 10, "Blue", "Ford", "Van E100", 0, 1976 },
                    { 11, "Maroon", "Ford", "LTD", 0, 1979 },
                    { 12, "Silver", "Toyota", "Celica", 0, 1983 },
                    { 13, "Brown", "Volkswagen", "Beetle", 0, 1965 },
                    { 14, "Brown/Red Stolen", "Toyota", "Corolla", 0, 1977 },
                    { 15, "White", "Chevy", "Monte Carlo", 0, 1973 },
                    { 16, "Blue", "Chevy", "Chevette", 0, 1976 },
                    { 17, "Brown", "Chevy", "Malibu", 0, 1975 },
                    { 18, "Blue", "Pontiac", "Firebird", 0, 1976 },
                    { 19, "Red", "Oldsmobile", "Omega", 0, 1974 },
                    { 20, "Silver/BlackGold", "Nissan", "Datsun 2 Plus 2", 0, 1977 },
                    { 21, "Brown", "Ford", "Grenada", 0, 1975 },
                    { 22, "Silver/Blue", "Toyota", "Celica", 0, 1985 },
                    { 23, "Brown", "Jeep", "Wagoneer", 0, 1975 },
                    { 24, "Blue", "Oldsmobile", "Delta 88", 0, 1985 },
                    { 25, "Beige", "Chevy", "Chevelle Wagon", 0, 1967 },
                    { 26, "White", "Chevy", "Malibu", 0, 1981 },
                    { 27, "Red", "Jeep", "Wrangler", 0, 1990 },
                    { 28, "Blue", "Oldsmobile", "Aurora", 0, 1996 },
                    { 29, "Grey", "Oldsmobile", "Cutlass", 0, 1975 },
                    { 30, "Silver", "Mazda", "926", 0, 1993 },
                    { 31, "Blue/Off White Blueish", "Austin", "Healey", 0, 1971 },
                    { 32, "Black", "Toyota", "Camry", 0, 2000 },
                    { 33, "Blue", "Toyota", "Tacoma", 0, 2008 },
                    { 34, "Black", "Ford", "Mustang", 0, 1965 },
                    { 35, "Green", "Chevy", "210/Belair", 0, 1954 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "CarId", "UserName" },
                values: new object[] { 1, 0, "Pop" });

            migrationBuilder.CreateIndex(
                name: "IX_Car_UserId",
                table: "Car",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_User_UserId",
                table: "Car",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_User_UserId",
                table: "Car");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Car",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_UserId",
                table: "Car");

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "CarId",
                keyColumnType: "int",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Car");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "User",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "NoteId",
                table: "Note",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Car",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "User",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Car",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Car",
                table: "Car",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "Color", "Make", "Model", "Year" },
                values: new object[,]
                {
                    { 1, "Blue", "Chevy", "Biscayne", 1968 },
                    { 2, "Blue", "Ford", "Fairlane", 1967 },
                    { 3, "Turquoise Blue/Green", "Volkswagen", "Beetle", 1965 },
                    { 4, "Green", "Chevy", "Impala", 1966 },
                    { 5, "Green", "Ford", "Pinto", 1972 },
                    { 6, "Beige", "Volkswagen", "Beetle", 1964 },
                    { 7, "Beige", "Nissan", "Datsun", 1967 },
                    { 8, "Maroon", "Ford", "Fairlane", 1963 },
                    { 9, "Light Blue", "Dodge", "Monaco", 1975 },
                    { 10, "Blue", "Ford", "Van E100", 1976 },
                    { 11, "Maroon", "Ford", "LTD", 1979 },
                    { 12, "Silver", "Toyota", "Celica", 1983 },
                    { 13, "Brown", "Volkswagen", "Beetle", 1965 },
                    { 14, "Brown/Red Stolen", "Toyota", "Corolla", 1977 },
                    { 15, "White", "Chevy", "Monte Carlo", 1973 },
                    { 16, "Blue", "Chevy", "Chevette", 1976 },
                    { 17, "Brown", "Chevy", "Malibu", 1975 },
                    { 18, "Blue", "Pontiac", "Firebird", 1976 },
                    { 19, "Red", "Oldsmobile", "Omega", 1974 },
                    { 20, "Silver/BlackGold", "Nissan", "Datsun 2 Plus 2", 1977 },
                    { 21, "Brown", "Ford", "Grenada", 1975 },
                    { 22, "Silver/Blue", "Toyota", "Celica", 1985 },
                    { 23, "Brown", "Jeep", "Wagoneer", 1975 },
                    { 24, "Blue", "Oldsmobile", "Delta 88", 1985 },
                    { 25, "Beige", "Chevy", "Chevelle Wagon", 1967 },
                    { 26, "White", "Chevy", "Malibu", 1981 },
                    { 27, "Red", "Jeep", "Wrangler", 1990 },
                    { 28, "Blue", "Oldsmobile", "Aurora", 1996 },
                    { 29, "Grey", "Oldsmobile", "Cutlass", 1975 },
                    { 30, "Silver", "Mazda", "926", 1993 },
                    { 31, "Blue/Off White Blueish", "Austin", "Healey", 1971 },
                    { 32, "Black", "Toyota", "Camry", 2000 },
                    { 33, "Blue", "Toyota", "Tacoma", 2008 },
                    { 34, "Black", "Ford", "Mustang", 1965 },
                    { 35, "Green", "Chevy", "210/Belair", 1954 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "UserName" },
                values: new object[] { 1, "AJ" });
        }
    }
}
