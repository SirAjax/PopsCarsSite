using EFTest.Models;

namespace PopsCars
{
    public interface IUserService
	{
		Task<List<User>> GetAllUsers();

		Task<List<User>> MainUserSearch(string search);

		Task<bool> AddUser(User user);

		Task<bool> DeleteUser(User user);
	
		Task<bool> UpdateUser(User user);

	}
}
