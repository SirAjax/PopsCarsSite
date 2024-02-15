﻿using EFTest.Models;
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

		public async Task<CommonResponse<User>> AddUser(User user)
		{
			var retValue = new CommonResponse<User>();

			try
			{
				retValue = await _userRepository.Add(user);
			}
			catch (Exception ex)
			{
				await retValue.SetExceptionAsync(ex);
			}

			return retValue;
		}

		public async Task<CommonResponse<List<User>>> GetAllUsers()
		{
			var listOfAllUsers = new CommonResponse<List<User>>();

			try 
			{
				List<User> userList = _userRepository.GetAll().ToList();
				listOfAllUsers.Value = userList;
			}

			catch (Exception ex) 
			
			{ 
				await listOfAllUsers.SetExceptionAsync(ex);
			}

			return listOfAllUsers;
		}

		public async Task<CommonResponse<User>> GetUserById(int Id)
		{
			var user = new CommonResponse<User>();
			try
			{
				user.Value =  _userRepository.GetById(Id);
			}

			catch (Exception ex) 
			{
				await user.SetExceptionAsync(ex);
			}
			
			return user;

		}
		public async Task<CommonResponse<List<User>>> MainUserSearch(string search)
		{
			var searchResults = new CommonResponse<List<User>>();

			try
			{
				List<User> userList =  _userRepository.GetAll().ToList();
				string[] searchOptions = search.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
					searchResults.Value = userList.Where(c =>
					searchOptions.All(term => c.UserName.ToString().Contains(term, StringComparison.InvariantCultureIgnoreCase))
				).ToList();
			}

			catch (Exception ex) 
			
			{
				await searchResults.SetExceptionAsync(ex);
			}
			return searchResults;
		}

		public async Task<CommonResponse<User>> UpdateUser(User user)
		{
			var retVal = new CommonResponse<User>();

			try
			{
				retVal = await _userRepository.UpdateAsync(user);
			}
            
			catch (Exception ex)
			{
				retVal.SetExceptionAsync(ex);
			}

			return retVal;
        }
		public async Task<CommonResponse<bool>> DeleteUser(User user) 
		{
			var retVal = new CommonResponse<bool>();
			try
			{
				retVal = await _userRepository.Delete(user);
			}
			catch (Exception ex)
			{ 
				retVal.SetExceptionAsync(ex);	
			}

			return retVal;
		}
	}
}
