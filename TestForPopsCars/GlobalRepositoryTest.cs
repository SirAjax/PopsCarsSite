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
		var model = new Car() { Make = "testMake"};
		bool actual = repository.Add(model);
		Assert.IsTrue(actual);
	}

	[TestMethod]
	public async Task Does_Delete_Return_Success()
	{
		var model = new Car() { Make = "testMake" };
		context.Add(model);
		context.SaveChanges();
		bool actual = repository.Delete(model);
		Assert.IsTrue(actual);
	}
	
}

