using EFTest.Models;

namespace PopsCars
{
    public interface IUserService
	{
		Task<List<User>> GetAllUsers();

		Task<List<User>> MainUserSearch(string search);

		Task AddUser(User user);

		Task DeleteUser(User user);
	
		Task UpdateUser(User user);

	}
}
