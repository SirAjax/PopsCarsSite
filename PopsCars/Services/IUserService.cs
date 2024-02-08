using EFTest.Models;
using PopsCarsSite.Common.Models;

namespace PopsCars
{
    public interface IUserService
	{
		Task<CommonResponse<List<User>>> GetAllUsers();

		Task<CommonResponse<List<User>>> MainUserSearch(string search);

		Task<CommonResponse<bool>> AddUser(User user);

		Task<CommonResponse<bool>> DeleteUser(User user);

		Task<CommonResponse<bool>> UpdateUser(User user);

		Task<CommonResponse<User>> GetUserById(int id);

	}
}
