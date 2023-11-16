using Microsoft.EntityFrameworkCore;
using EFTest;
using EFTest.Models;
using Microsoft.Data.Sqlite;
using System.Runtime.CompilerServices;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

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
		var newUser = userRepository.CreateUser(user);
		Assert.IsNotNull(newUser);
	}

	[TestMethod]
	public async Task Does_GetAllUserAsync_Return_Success()
	{
		var userRepository = new UserRepository(context);
		var actualListOfUsers = await userRepository.GetAllUserAsync();
		Assert.IsNotNull(actualListOfUsers);

	}

	[TestMethod]
	public async Task Does_GetUserByName_Return_Success()
	{

		{
			var user = new User { UserName = "testName", ID = 5 };
			var userRepository = new UserRepository(context);
			context.Add(user);
			context.SaveChanges();
			var searchedUser = await userRepository.GetUserByName("testName");
			Assert.AreEqual(user, searchedUser.FirstOrDefault());
		}
	}

	[TestMethod]
	public async Task Does_DeleteUser_Return_Success()
	{
		var user = new User { UserName = "testName", ID = 5 };
		var userRepository = new UserRepository(context);
		context.Add(user);
		context.SaveChanges();
		userRepository.DeleteUser(user);
		var SavedUserDetails = context.User.FirstOrDefault(user => user.ID == 5);
		Assert.IsNull(SavedUserDetails);
	}

	[TestMethod]
	public async Task Does_GetUserObject_Return_Success()
	{

		var user = new User { UserName = "testName", ID = 5 };
		var userRepository = new UserRepository(context);
		context.Add(user);
		context.SaveChanges();
		var searchedUser = userRepository.GetUserObject("testName");
		Assert.AreEqual(user, searchedUser);
	}
	[TestMethod]
	public async Task Does_UpdateUser_Return_Success()
	{
		string originalUserName = "testName", updatedUserName = "updatedTestName";
		var user = new User { UserName = originalUserName, ID = 5 };
		var userRepository = new UserRepository(context);
		context.Add(user);
		context.SaveChanges();
		var updatedUser = new User { UserName = updatedUserName, ID = 5 };
		User actual = userRepository.UpdateUser(updatedUser);
		Assert.AreEqual(updatedUserName, actual.UserName);
		Assert.AreNotEqual(originalUserName, user.UserName);
	}
}