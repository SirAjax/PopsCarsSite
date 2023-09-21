using EFTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFTest.SeededData;
public class CarConfiguration : IEntityTypeConfiguration<Car>
{
	public void Configure(EntityTypeBuilder<Car> builder)
	{
		builder.HasData(
			new Car(1968, "Chevy", "Biscayne", "Blue", 1),
			new Car(1967, "Ford", "Fairlane", "Blue", 2),
			new Car(1965, "Volkswagen", "Beetle", "Turquoise Blue/Green", 3),
			new Car(1966, "Chevy", "Impala", "Green", 4),
			new Car(1972, "Ford", "Pinto", "Green", 5),
			new Car(1964, "Volkswagen", "Beetle", "Beige", 6),
			new Car(1967, "Nissan", "Datsun", "Beige", 7),
			new Car(1963, "Ford", "Fairlane", "Maroon", 8),
			new Car(1975, "Dodge", "Monaco", "Light Blue", 9),
			new Car(1976, "Ford", "Van E100", "Blue", 10),
			new Car(1979, "Ford", "LTD", "Maroon", 11),
			new Car(1983, "Toyota", "Celica", "Silver", 12),
			new Car(1965, "Volkswagen", "Beetle", "Brown", 13),
			new Car(1977, "Toyota", "Corolla", "Brown/Red Stolen", 14),
			new Car(1973, "Chevy", "Monte Carlo", "White", 15),
			new Car(1976, "Chevy", "Chevette", "Blue", 16),
			new Car(1975, "Chevy", "Malibu", "Brown", 17),
			new Car(1976, "Pontiac", "Firebird", "Blue", 18),
			new Car(1974, "Oldsmobile", "Omega", "Red", 19),
			new Car(1977, "Nissan", "Datsun 2 Plus 2", "Silver/BlackGold", 20),
			new Car(1975, "Ford", "Grenada", "Brown", 21),
			new Car(1985, "Toyota", "Celica", "Silver/Blue", 22),
			new Car(1975, "Jeep", "Wagoneer", "Brown", 23),
			new Car(1985, "Oldsmobile", "Delta 88", "Blue", 24),
			new Car(1967, "Chevy", "Chevelle Wagon", "Beige", 25),
			new Car(1981, "Chevy", "Malibu", "White", 26),
			new Car(1990, "Jeep", "Wrangler", "Red", 27),
			new Car(1996, "Oldsmobile", "Aurora", "Blue", 28),
			new Car(1975, "Oldsmobile", "Cutlass", "Grey", 29),
			new Car(1993, "Mazda", "926", "Silver", 30),
			new Car(1971, "Austin", "Healey", "Blue/Off White Blueish", 31),
			new Car(2000, "Toyota", "Camry", "Black", 32),
			new Car(2008, "Toyota", "Tacoma", "Blue", 33),
			new Car(1965, "Ford", "Mustang", "Black", 34),
			new Car(1954, "Chevy", "210/Belair", "Green", 35)
		);
	}
}
