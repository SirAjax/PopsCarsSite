using EFTest.Models;
using Microsoft.AspNetCore.Components;
using PopsCars;

namespace PopsCarsSite.Pages
{
	public class InitialUserComponent : ComponentBase
	{

		protected List<Car> ListOfCars = new();
		protected List<User> ListOfUsers = new();
		protected List<Note> ListOfNotes = new();
		protected Note? newNote = new Note();

		[Inject]
		private IService _service { get; set; } = default!;
		protected override async Task OnInitializedAsync()
		{
			await PopulateCarList();
			await PopulateUserList();
		}
		protected async Task PopulateCarList()
		{
			ListOfCars = await _service.GetAllCars();
		}
		
		[Inject]
		private IUserService _userservice { get; set; } = default!;
		protected async Task PopulateUserList()
		{
			ListOfUsers = await _userservice.GetAllUsers();

		}

		[Inject]

		private INoteService _noteservice { get; set; } = default!;
		
		protected async Task PopulateNoteList()
		{
			ListOfNotes = await _noteservice.GetNotes();
		}
           protected async Task AddNote()
        {
            await _noteservice.AddNote(newNote);
            await PopulateNoteList();
        }
    }
}
