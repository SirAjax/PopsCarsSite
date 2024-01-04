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

		public async Task<bool> AddUser(User user)
		{
			return await _userRepository.Add(user);
		}

		public async Task<List<User>> GetAllUsers()
		{
			return  _userRepository.GetAll().ToList();
		}

		public async Task<User> GetUserById(int Id)
		{
			return _userRepository.GetById(Id);
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

		public async Task<bool> UpdateUser(User user)
		{
            return await _userRepository.UpdateAsync(user);
        }
		public async Task<bool> DeleteUser(User user) 
		{
			return await _userRepository.Delete(user);
		}
	}
}
