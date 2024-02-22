using Moq;
using PopsCarsSite.Common.Models;
using FluentAssertions;

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
	public async Task Does_GetAllCarsWithNotes_Return_Success()
	{
		var carsRepository = new CarsRepository(context);

		var result = await carsRepository.GetAllCarsWithNotes(0);

		Assert.IsFalse(result.Error);
	}
	[TestMethod]
	public async Task Does_GetAllCarsWithNotes_Return_Success_WithNote()
	{
		var car = new Car { Make = "test make", UserId = 1, Id = 1 };
		var note = new Note { Comments = "test comment", CarId = 1 };
		context.Add(car);
		context.Add(note);
		context.SaveChanges();

		var carsRepository = new CarsRepository(context);

		var result = await carsRepository.GetAllCarsWithNotes(1);

		Assert.AreEqual(note, result.Value.First().Notes.First());
	}

	[TestMethod]
	public async Task Does_GetAllCarsWithNotes_Return_Error()
	{
		contextMoq.Setup(x => x.Car).Throws(new Exception());
		var carsRepository = new CarsRepository(contextMoq.Object);

		var result = await carsRepository.GetAllCarsWithNotes(0);

		Assert.IsTrue(result.Error);
		result.Error.Should().BeTrue();
	}

	
}