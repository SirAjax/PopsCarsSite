using EFTest;
using EFTest.Models;

namespace PopsCars
{
	public interface IUserService
	{
		Task<List<User>> GetAllUsers();

		Task<List<User>> MainUserSearch(string search);

		Task<bool> CreateUser(User user);

		Task DeleteUser(User user);
	

	}
}
