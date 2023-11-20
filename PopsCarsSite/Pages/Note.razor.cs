using EFTest.Models;
using Microsoft.AspNetCore.Components;
using PopsCars;
using System.Diagnostics.Eventing.Reader;

namespace PopsCarsSite.Note
{
	public class NoteComponent : ComponentBase
	{
		protected List<EFTest.Models.Note ListOfUsers = new();
		protected string? search;
		protected EFTest.Models.Note? newNote = new();
		protected EFTest.Models.Note? noteToDelete = new();

		[Inject]
		private INoteService _noteservice { get; set; } = default!;


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
			var result = await _userservice.CreateUser(newUser);
			await PopulateList();
		}

		protected async Task DeleteUser()
		{
			await _userservice.DeleteUser(userToDelete);
		}
	}

}

