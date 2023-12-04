using EFTest.Models;

namespace PopsCars
{
    public interface IUserService
	{
		Task<List<User>> GetAllUsers();

		Task<List<User>> MainUserSearch(string search);

		Task<User> CreateUser(User user);

		Task DeleteUser(User user);
	

	}
}
