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

		public async Task<bool> CreateUser(User user)
		{
			return _userRepository.Add(user);
		}

		public async Task<List<User>> GetAllUsers()
		{
			return  _userRepository.GetAll().ToList();
		}

		public async Task<List<User>> MainUserSearch(string search)
		{
			List<User> userList = _userRepository.GetAll().ToList();
			string[] searchOptions = search.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

			var searchResults = userList.Where(c =>
				searchOptions.All(term => c.UserName.ToString().Contains(term, StringComparison.InvariantCultureIgnoreCase))
			).ToList();

			return searchResults;
		}

		public async Task<bool> DeleteUser(User user) 
		{
			return _userRepository.Delete(user);
		}
	}
}
