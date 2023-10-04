using EFTest.Models;
using EFTest;

namespace PopsCars
{
	public class UserService: IUserService
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}
		public async Task<List<User>> GetAllUsers()
		{
			return await _userRepository.GetAllUserAsync();
		}
	}
}
