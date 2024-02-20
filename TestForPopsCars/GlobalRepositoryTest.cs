namespace TestForPopsCars;

[TestClass]
public class GenericRepositoryTest
{
	private DbContextOptions<PopsCarsContext> dbContextOptions;
	private PopsCarsContext context;
	private IGenericRepository<Car> repository;


	[TestInitialize]
	public void Setup()
	{
		dbContextOptions = new DbContextOptionsBuilder<PopsCarsContext>().UseInMemoryDatabase("test").Options;
		context = new(dbContextOptions);
		repository = new GenericRepository<Car>(context);
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
	public async Task Does_Delete_Return_Success()
	{
		var model = new Car() { Make = "testMake" };
		context.Add(model);
		context.SaveChanges();

		var result = await repository.Delete(model);
		
		Assert.IsTrue(result.Value);
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

	public async Task Does_UpdateAsync_Return_Success()
	{
        var model = new Car() { Make = "testMake" };
        context.Add(model);
        context.SaveChanges();
        model.Make = "testMake2";

        var actual = await repository.UpdateAsync(model);

        Assert.AreEqual(model, actual.Value);
    }
}
