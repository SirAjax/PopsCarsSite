namespace TestForPopsCars;
[TestClass]
public class UserRepositoryTest
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
	public async Task Does_CreateUser_Return_Success()
	{
		var user = new User { UserName = "test", ID = 5 };
		var userRepository = new UserRepository(context);
		var newUser = userRepository.Add(user);
		Assert.IsNotNull(newUser);
	}

	[TestMethod]
	public async Task Does_GetAllUserAsync_Return_Success()
	{
		var userRepository = new UserRepository(context);
		var actualListOfUsers = userRepository.GetAll();
		Assert.IsNotNull(actualListOfUsers);

	}



	[TestMethod]
	public async Task Does_DeleteUser_Return_Success()
	{
		var user = new User { UserName = "testName", ID = 5 };
		var userRepository = new UserRepository(context);
		context.Add(user);
		context.SaveChanges();
		userRepository.Delete(user);
		var SavedUserDetails = context.User.FirstOrDefault(user => user.ID == 5);
		Assert.IsNull(SavedUserDetails);
	}


	[TestMethod]
	public async Task Does_UpdateUser_Return_Success()
	{
		string originalUserName = "testName", updatedUserName = "updatedTestName";
		var user = new User { UserName = originalUserName, ID = 5 };
		var userRepository = new UserRepository(context);
		context.Add(user);
		context.SaveChanges();
		user.UserName = updatedUserName;
		var actual = await userRepository.UpdateAsync(user);
		Assert.IsTrue(actual);
	}
}