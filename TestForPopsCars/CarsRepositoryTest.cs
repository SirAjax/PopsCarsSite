using Microsoft.EntityFrameworkCore;
using EFTest;
using EFTest.Models;
using Microsoft.Data.Sqlite;
using System.Runtime.CompilerServices;
using System.Diagnostics.CodeAnalysis;

namespace TestForPopsCars;

[TestClass]
public class CarsRepositoryTest
{
	[TestMethod]
	public async Task Does_AddCar_Return_Success()
	{
		var builder = new DbContextOptionsBuilder<PopsCarsContext>().UseInMemoryDatabase("test");

		//builder.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Name }, Microsoft.Extensions.Logging.LogLevel.Information).EnableSensitiveDataLogging();

		using (var context = new PopsCarsContext(builder.Options))
		{
			var car = new Car { Year = 5, Make = "unit test", Model = "TEST", Color = "Turqouise", Id = 18 };

			var carsRepository = new CarsRepository(context);
			var newCar = carsRepository.Add(car);
			Assert.IsNotNull(newCar);
		}
	}
	[TestMethod]
	public async Task Does_DeleteCar_Return_Success()
	{
		var builder = new DbContextOptionsBuilder<PopsCarsContext>().UseInMemoryDatabase("test");

		using (var context = new PopsCarsContext(builder.Options))
		{
			var car = new Car { Id = 18, Make = "unit test", Model = "Test", Color = "Orange", Year = 2017 };
			var carsRepository = new CarsRepository(context);
			context.Add(car);
			context.SaveChanges();
			carsRepository.Delete(car);
			var savedCarDetails = context.Car.Where(c => c.Make == "unit test").FirstOrDefault();
			Assert.IsNull(savedCarDetails);
		}
	}
	[TestMethod]
	public async Task Does_GetCarsAsync_Return_Success()
	{
		var builder = new DbContextOptionsBuilder<PopsCarsContext>().UseInMemoryDatabase("test");

		using (var context = new PopsCarsContext(builder.Options))
		{
			var carsRepository = new CarsRepository(context);
			carsRepository.GetAll();
			Assert.IsNotNull(carsRepository);
		}
	}
}