using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFTest.Migrations
{
    /// <inheritdoc />
    public partial class InitialUserV4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    NoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CarId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.NoteId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Car_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Note",
                columns: new[] { "NoteId", "CarId", "Comments", "UserId" },
                values: new object[] { 1, 1, "this car should be a Chevy Biscayne", 1 });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID", "UserName" },
                values: new object[,]
                {
                    { 1, "Pop" },
                    { 2, "AJ" },
                    { 3, "Michael" }
                });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "Color", "Make", "Model", "UserId", "Year" },
                values: new object[,]
                {
                    { 1, "Blue", "Chevy", "Biscayne", 1, 1968 },
                    { 2, "Blue", "Ford", "Fairlane", 1, 1967 },
                    { 3, "Turquoise Blue/Green", "Volkswagen", "Beetle", 1, 1965 },
                    { 4, "Green", "Chevy", "Impala", 1, 1966 },
                    { 5, "Green", "Ford", "Pinto", 1, 1972 },
                    { 6, "Beige", "Volkswagen", "Beetle", 1, 1964 },
                    { 7, "Beige", "Nissan", "Datsun", 1, 1967 },
                    { 8, "Maroon", "Ford", "Fairlane", 1, 1963 },
                    { 9, "Light Blue", "Dodge", "Monaco", 1, 1975 },
                    { 10, "Blue", "Ford", "Van E100", 1, 1976 },
                    { 11, "Maroon", "Ford", "LTD", 1, 1979 },
                    { 12, "Silver", "Toyota", "Celica", 1, 1983 },
                    { 13, "Brown", "Volkswagen", "Beetle", 1, 1965 },
                    { 14, "Brown/Red Stolen", "Toyota", "Corolla", 1, 1977 },
                    { 15, "White", "Chevy", "Monte Carlo", 1, 1973 },
                    { 16, "Blue", "Chevy", "Chevette", 1, 1976 },
                    { 17, "Brown", "Chevy", "Malibu", 1, 1975 },
                    { 18, "Blue", "Pontiac", "Firebird", 1, 1976 },
                    { 19, "Red", "Oldsmobile", "Omega", 1, 1974 },
                    { 20, "Silver/BlackGold", "Nissan", "Datsun 2 Plus 2", 1, 1977 },
                    { 21, "Brown", "Ford", "Grenada", 1, 1975 },
                    { 22, "Silver/Blue", "Toyota", "Celica", 1, 1985 },
                    { 23, "Brown", "Jeep", "Wagoneer", 1, 1975 },
                    { 24, "Blue", "Oldsmobile", "Delta 88", 1, 1985 },
                    { 25, "Beige", "Chevy", "Chevelle Wagon", 1, 1967 },
                    { 26, "White", "Chevy", "Malibu", 1, 1981 },
                    { 27, "Red", "Jeep", "Wrangler", 1, 1990 },
                    { 28, "Blue", "Oldsmobile", "Aurora", 1, 1996 },
                    { 29, "Grey", "Oldsmobile", "Cutlass", 1, 1975 },
                    { 30, "Silver", "Mazda", "926", 1, 1993 },
                    { 31, "Blue/Off White Blueish", "Austin", "Healey", 1, 1971 },
                    { 32, "Black", "Toyota", "Camry", 1, 2000 },
                    { 33, "Blue", "Toyota", "Tacoma", 1, 2008 },
                    { 34, "Black", "Ford", "Mustang", 1, 1965 },
                    { 35, "Green", "Chevy", "210/Belair", 1, 1954 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_UserId",
                table: "Car",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
