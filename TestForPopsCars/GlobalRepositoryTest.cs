using FluentAssertions;
using Moq;

namespace TestForPopsCars;

[TestClass]
public class GenericRepositoryTest
{
	private DbContextOptions<PopsCarsContext> dbContextOptions;
	private PopsCarsContext context;
	private IGenericRepository<Car> repository;
	private Mock<PopsCarsContext> contextMoq;


	[TestInitialize]
	public void Setup()
	{
		dbContextOptions = new DbContextOptionsBuilder<PopsCarsContext>().UseInMemoryDatabase("test").Options;
		context = new(dbContextOptions);
		repository = new GenericRepository<Car>(context);
		contextMoq = new(dbContextOptions);
	}
	[TestCleanup]
	public void Cleanup()
	{
		context.Database.EnsureDeleted();
	}

	[TestMethod]
	public async Task Does_Add_Return_Success()
	{
		var model = new Car() { Make = "testMake" };

		var actual = await repository.Add(model);

		Assert.AreEqual(model, actual.Value);
	}

	[TestMethod]

	public async Task Does_Add_Return_Error()
	{
		contextMoq.Setup(x => x.Add(It.IsAny<Car>())).Throws(new Exception());
		var testRepository = new GenericRepository<Car>(contextMoq.Object);
		var model = new Car() { Make = "Test Model" };

		var actual = await testRepository.Add(model);

		actual.Error.Should().BeTrue();
	}

	[TestMethod]
	public async Task Does_Delete_Return_Success()
	{
		var model = new Car() { Make = "testMake" };
		context.Add(model);
		context.SaveChanges();

		var result = await repository.Delete(model);

		Assert.IsTrue(result.Value);
	}

	[TestMethod]
	public async Task Does_Delete_Return_Error()
	{
		contextMoq.Setup(x => x.Remove(It.IsAny<Car>())).Throws(new Exception());
		var testRepository = new GenericRepository<Car>(contextMoq.Object);
		var model = new Car() { Make = "Test Make" };

		var actual = await testRepository.Delete(model);

		actual.Error.Should().BeTrue();
	}

	[TestMethod]
	public async Task Does_GetAll_Return_Success()
	{
		var model = new Car() { Make = "testMake" };
		context.Add(model);
		context.SaveChanges();

		var actual = repository.GetAll();

		Assert.IsNotNull(actual);
	}

	[TestMethod]
	public async Task Does_GetAll_Return_Error()
	{
		contextMoq.Setup(x => x.Car).Throws(new Exception());
		var testRepository = new GenericRepository<List<Car>>(contextMoq.Object);
		var model = new List<Car>() { new Car { Make = "Test Make" }, new Car { Make = "Test Make 2" } };

		var actual = await testRepository.GetAll();

		actual.Error.Should().BeTrue();
	}

	[TestMethod]

	public async Task Does_UpdateAsync_Return_Success()
	{
		var model = new Car() { Make = "testMake" };
		context.Add(model);
		context.SaveChanges();
		model.Make = "testMake2";

		var actual = await repository.UpdateAsync(model);

		Assert.AreEqual(model, actual.Value);
	}

	[TestMethod]
	public async Task Does_UpdateAsync_Return_Error()
	{

		contextMoq.Setup(x => x.Car).Throws(new Exception());
		var testRepository = new GenericRepository<Car>(contextMoq.Object);
		var model = new Car() { Make = "Test Make" };

		var actual = await testRepository.UpdateAsync(model);

		actual.Error.Should().BeTrue();
	}
}
