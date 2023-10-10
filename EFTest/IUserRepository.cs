using EFTest.Models;

namespace EFTest;
public interface IUserRepository
{
	Task<List<User>> GetAllUserAsync();
	Task<List<User>> GetUserByName(string userName);

	Task<User> CreateUser(User user);

	void DeleteUser(User user);
}