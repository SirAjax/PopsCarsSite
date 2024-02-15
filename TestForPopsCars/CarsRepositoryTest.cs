using Moq;

namespace TestForPopsCars;


[TestClass]
public class CarsRepositoryTest
{
	private DbContextOptions<PopsCarsContext> dbContextOptions;
	private PopsCarsContext context;
	private Mock<PopsCarsContext> contextMoq;

	[TestInitialize]
	public void Setup()
	{
		dbContextOptions = new DbContextOptionsBuilder<PopsCarsContext>().UseInMemoryDatabase("test").Options;
		context = new(dbContextOptions);
		contextMoq = new(dbContextOptions);
	}
	[TestCleanup]
	public void Cleanup()
	{
		context.Database.EnsureDeleted();
	}


	[TestMethod]
	public async Task Does_AddCar_Return_Success()
	{
		var car = new Car { Year = 5, Make = "unit test", Model = "TEST", Color = "Turqouise", Id = 18 };
		var carsRepository = new CarsRepository(context);
		
		var newCar = carsRepository.Add(car);
		
		Assert.IsNotNull(newCar);
	}

	[TestMethod]
	public async Task Does_AddCar_Return_Error()
	{
		contextMoq.Setup(x => x.Add(It.IsAny<Car>())).Throws(new Exception());
		var carsRepository = new CarsRepository(context);
		Car car = new();

		var result = await carsRepository.Add(car);

		Assert.IsFalse(result);
	}

	[TestMethod]
	public async Task Does_DeleteCar_Return_Success()
	{
		var car = new Car { Make = "unit test" };
		var carsRepository = new CarsRepository(context);
		context.Add(car);
		context.SaveChanges();

		await carsRepository.Delete(car);

		var savedCarDetails = context.Car.Where(c => c.Make == "unit test").FirstOrDefault();
		Assert.IsNull(savedCarDetails);
	}

	[TestMethod]

	public async Task Does_DeleteCar_Return_Error()
	{
		contextMoq.Setup(x => x.Remove(It.IsAny<Car>())).Throws(new Exception());
		var car = new Car { Make = "unit test" };
		var carsRepository = new CarsRepository(context);
		context.Add(car);
		context.SaveChanges();

		var result = await carsRepository.Delete(car);

		Assert.IsTrue(result);
	}
	
	[TestMethod]
	public async Task Does_GetCarsAsync_Return_Success()
	{
		var carsRepository = new CarsRepository(context);

		carsRepository.GetAll();
		
		Assert.IsNotNull(carsRepository);
	}

	[TestMethod]

	public async Task Does_GetCarsAsync_Return_Error()
	{
		contextMoq.Setup(x => x.(It.IsAny<Car>())).Throws(new Exception());
		var carsRepository = new CarsRepository(context);

		var result = carsRepository.GetAll();

		Assert.IsFalse(result);
	}

	[TestMethod]

	public async Task Does_UpdateCars_Return_Success()
	{
		var car = new Car { Make = "Test Car", Model = "Test Model", Year = 2008 };
		var carRepository = new CarsRepository(context);
		context.Add(car);
		context.SaveChanges();
		car.Model = "Updated Model";
		car.Year = 2010;

		var updatedCar = await carRepository.UpdateAsync(car);

		Assert.IsTrue(updatedCar);
	}

	[TestMethod]

	public async Task Does_UpdateCars_ReturnError()
	{
		contextMoq.Setup(x => x.Update(It.IsAny<Car>())).Throws(new Exception());
		var car = new Car { Make = "Test Car", Model = "Test Model", Year = 2008 };
		var carRepository = new CarsRepository(context);
		context.Add(car);
		context.SaveChanges();
		car.Model = "Updated Model";
		car.Year = 2010;

		var updatedCar = await carRepository.UpdateAsync(car);

		Assert.IsFalse(updatedCar);
	}
}