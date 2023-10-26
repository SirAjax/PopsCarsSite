using EFTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFTest.SeededData;
public class CarConfiguration : IEntityTypeConfiguration<Car>
{
	public void Configure(EntityTypeBuilder<Car> builder)
	{
		builder.HasData(
			new Car(1968, "Chevy", "Biscayne", "Blue", 1, 1),
			new Car(1967, "Ford", "Fairlane", "Blue", 2, 1),
			new Car(1965, "Volkswagen", "Beetle", "Turquoise Blue/Green", 3, 1),
			new Car(1966, "Chevy", "Impala", "Green", 4, 1),
			new Car(1972, "Ford", "Pinto", "Green", 5, 1),
			new Car(1964, "Volkswagen", "Beetle", "Beige", 6, 1),
			new Car(1967, "Nissan", "Datsun", "Beige", 7, 1),
			new Car(1963, "Ford", "Fairlane", "Maroon", 8, 1),
			new Car(1975, "Dodge", "Monaco", "Light Blue", 9, 1),
			new Car(1976, "Ford", "Van E100", "Blue", 10, 1),
			new Car(1979, "Ford", "LTD", "Maroon", 11, 1),
			new Car(1983, "Toyota", "Celica", "Silver", 12, 1),
			new Car(1965, "Volkswagen", "Beetle", "Brown", 13, 1),
			new Car(1977, "Toyota", "Corolla", "Brown/Red Stolen", 14, 1),
			new Car(1973, "Chevy", "Monte Carlo", "White", 15, 1),
			new Car(1976, "Chevy", "Chevette", "Blue", 16, 1),
			new Car(1975, "Chevy", "Malibu", "Brown", 17, 1),
			new Car(1976, "Pontiac", "Firebird", "Blue", 18, 1),
			new Car(1974, "Oldsmobile", "Omega", "Red", 19, 1),
			new Car(1977, "Nissan", "Datsun 2 Plus 2", "Silver/BlackGold", 20, 1),
			new Car(1975, "Ford", "Grenada", "Brown", 21, 1),
			new Car(1985, "Toyota", "Celica", "Silver/Blue", 22, 1),
			new Car(1975, "Jeep", "Wagoneer", "Brown", 23, 1),
			new Car(1985, "Oldsmobile", "Delta 88", "Blue", 24, 1),
			new Car(1967, "Chevy", "Chevelle Wagon", "Beige", 25, 1),
			new Car(1981, "Chevy", "Malibu", "White", 26, 1),
			new Car(1990, "Jeep", "Wrangler", "Red", 27, 1),
			new Car(1996, "Oldsmobile", "Aurora", "Blue", 28, 1),
			new Car(1975, "Oldsmobile", "Cutlass", "Grey", 29, 1),
			new Car(1993, "Mazda", "926", "Silver", 30, 1),
			new Car(1971, "Austin", "Healey", "Blue/Off White Blueish", 31, 1),
			new Car(2000, "Toyota", "Camry", "Black", 32, 1),
			new Car(2008, "Toyota", "Tacoma", "Blue", 33, 1),
			new Car(1965, "Ford", "Mustang", "Black", 34, 1),
			new Car(1954, "Chevy", "210/Belair", "Green", 35, 1)
			);
	
	}
}
