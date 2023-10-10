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

		public async Task<User> CreateUser(User user)
		{
			return await _userRepository.CreateUser(user);
		}

		public async Task<List<User>> GetAllUsers()
		{
			return await _userRepository.GetAllUserAsync();
		}

		public async Task<List<User>> MainUserSearch(string search)
		{
			List<User> userList = await _userRepository.GetAllUserAsync();
			string[] searchOptions = search.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

			var searchResults = userList.Where(c =>
				searchOptions.All(term => c.UserName.ToString().Contains(term, StringComparison.InvariantCultureIgnoreCase))
			).ToList();

			return searchResults;
		}

		public async Task DeleteUser(User user) 
		{
			_userRepository.DeleteUser(user);
		}
	}
}
