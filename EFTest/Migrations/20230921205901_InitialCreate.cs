using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFTest.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

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
