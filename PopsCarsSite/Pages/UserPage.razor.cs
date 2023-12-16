using EFTest.Models;
using Microsoft.AspNetCore.Components;
using PopsCars;

namespace PopsCarsSite.Pages
{
	public class UserComponent : ComponentBase
	{
		protected List<User> ListOfUsers = new();
		protected string? search;
		protected User? newUser = new();
		protected User? userToDelete = new();
		protected User? userToUpdate = new();

		[Inject]
		private IUserService _userservice { get; set; } = default!;


		protected override async Task OnInitializedAsync()
		{
			await PopulateList();
		}

		protected async Task PopulateList()
		{
			ListOfUsers = await _userservice.GetAllUsers();
			newUser = new();
		}
		protected async Task FilterByUserSearch()
		{
			if (string.IsNullOrEmpty(search))
			{
				Console.WriteLine("no search criteria");
			}
			else
			{
				ListOfUsers = await _userservice.MainUserSearch(search);
			}
		}

		protected async Task AddUser()
		{
			await _userservice.AddUser(newUser);
			await PopulateList();
		}

		protected async Task DeleteUser(User user)
		{
			await _userservice.DeleteUser(user);
			await PopulateList();

		}

		protected async Task UpdateUser(User userToUpdate)
		{
			await _userservice.UpdateUser(userToUpdate);
			await PopulateList();
		}
	}

}

