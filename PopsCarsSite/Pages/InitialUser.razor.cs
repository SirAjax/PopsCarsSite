using EFTest.Models;
using Microsoft.AspNetCore.Components;
using PopsCars;
using System.Runtime.CompilerServices;


namespace PopsCarsSite.Pages
{
	public class InitialUserComponent : ComponentBase
	{

		protected List<Car> ListOfCars = new();
		protected List<Note> ListOfNotes = new();
		protected Car? newCar = new();
		protected Car? carToUpdate = new();
		protected Car? carToDelete = new();
		protected User? currentUser = new();
		protected Note? newNote = new();
		protected Note? noteToUpdate = new();
		protected Note? noteToDelete = new();
		protected Car? car;
		protected string search;

		[Inject]
		private IService _service { get; set; } = default!;

		[Inject]
		private IUserService _userservice { get; set; } = default!;
		
		[Inject]

		private INoteService _noteservice { get; set; } = default!;
		
		protected override async Task OnInitializedAsync()
		{
			await PopulateCarList();
			await PopulateUserList();
			await PopulateNoteList();
		}
		protected async Task PopulateCarList()
		{
			ListOfCars = await _service.GetCarByUserId(1);
		}

		protected async Task AddCar()
		{
			newCar.UserId = currentUser.ID;
			await _service.AddCar(newCar);
			await PopulateCarList();
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
		protected async Task UpdateCar(Car carToUpdate)
		{
			var carList = await _service.GetAllCars();
			var actualCarToUpdate = carList.FirstOrDefault(c => c.Id == carToUpdate.Id);
			if (actualCarToUpdate != null)
			{
				await _service.UpdateCar(actualCarToUpdate);
				await PopulateCarList();
			}
		}
		protected async Task PopulateUserList()
		{
			currentUser = await _userservice.GetUserById(1);
		}


		protected async Task PopulateNoteList()
		{
			ListOfNotes = await _noteservice.GetNoteById(1);
		}
		protected async Task AddNote()
		{
			newNote.UserId = currentUser.ID;
			newNote.CarId = newCar.Id;
			await _noteservice.AddNote(newNote);
			await PopulateNoteList();
		}
	}
}
