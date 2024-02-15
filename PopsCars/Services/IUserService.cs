using EFTest.Models;
using PopsCarsSite.Common.Models;

namespace PopsCars
{
    public interface IUserService
	{
		Task<CommonResponse<List<User>>> GetAllUsers();

		Task<CommonResponse<List<User>>> MainUserSearch(string search);

		Task<CommonResponse<User>> AddUser(User user);

		Task<CommonResponse<bool>> DeleteUser(User user);

		Task<CommonResponse<User>> UpdateUser(User user);

		Task<CommonResponse<User>> GetUserById(int id);
	}
}
