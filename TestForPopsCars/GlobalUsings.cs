global using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using EFTest;
using EFTest.Models;
using EFTest.GenericRepository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

[TestClass]
public class GenericRepositoryTest
{
	private DbContextOptions<PopsCarsContext> dbContextOptions;
	private PopsCarsContext context;

	[TestInitialize]
	public void Setup()
	{
		dbContextOptions = new DbContextOptionsBuilder<PopsCarsContext>().UseInMemoryDatabase("test").Options;
		context = new(dbContextOptions);
	}
	[TestCleanup]
	public void Cleanup()
	{
		context.Database.EnsureDeleted();
	}

	[TestMethod]
	public bool Does_Add_Return_Success()
	{
		var model = new Model();
		var repository = new GenericRepository(context);
		var newModel = repository.Add(model);

		Assert.IsTrue(newModel);
	}


