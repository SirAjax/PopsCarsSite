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
		protected Car? newCar = new();
        protected Car? carToUpdate = new();
		protected Car? carToDelete = new();
        protected Note? newNote = new();
		protected string search;
		[Inject]
		private IService _service { get; set; } = default!;
		protected override async Task OnInitializedAsync()
		{
			await PopulateCarList();
			await PopulateUserList();
			await PopulateNoteList();
		}
		protected async Task PopulateCarList()
		{
			ListOfCars = await _service.GetAllCars();
		}
		
		protected async Task AddCar()
		{
			await _service.AddCar(newCar);
		}
        protected async Task FilterBySearch()
        {
            if (string.IsNullOrEmpty(search))
            {
                Console.WriteLine("no search results");
            }
            else
            {
                ListOfCars = await _service.MainSearch(search);
            }
        }
        protected async Task UpdateCar()
		{
			await _service.UpdateCar(carToUpdate);
		}

		protected async Task DeleteCar()
		{
			await _service.DeleteCar(carToDelete);
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
