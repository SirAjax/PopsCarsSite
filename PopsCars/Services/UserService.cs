using EFTest.Models;
using EFTest;
using PopsCarsSite.Common.Models;

namespace PopsCars
{
	public class UserService: IUserService
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<CommonResponse<bool>> AddUser(User user)
		{
			var retValue = new CommonResponse<bool>();

			try
			{
				retValue.Value = await _userRepository.Add(user);
			}
			catch (Exception ex)
			{
				await retValue.SetExceptionAsync(ex);
			}

			return retValue;
		}

		public async Task<List<User>> GetAllUsers()
		{
			var listOfAllUsers = new CommonResponse<List<User>>();

			try 
			{
				CommonResponse<List<User>> userList = _userRepository.GetAll().ToList();
				listOfAllUsers.Value = userList.Value;
			}

			catch (Exception ex) 
			
			{ 
				await listOfAllUsers.SetExceptionAsync(ex);
			}

			return listOfAllUsers;
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
