using EFTest.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using PopsCars;
using PopsCarsSite.Shared;


namespace PopsCarsSite.Pages
{
	public class InitialUserComponent : ComponentBase
	{

		protected List<Car> ListOfCars = new();
		protected List<Note> ListOfNotes = new();
		protected Car? newCar = new();
		protected Car? carToUpdate = new();
		protected Car? carToDelete = new();
		protected int initialUser { get; set; } = 1;
		protected User? currentUser = new();
		protected Note? newNote = new();
		protected Note? noteToUpdate = new();
		protected Note? noteToDelete = new();
		protected string search;

		[Inject]
		private IService _service { get; set; } = default!;

		[Inject]
		private IUserService _userservice { get; set; } = default!;

		[Inject]

		private INoteService _noteservice { get; set; } = default!;

		[Inject]
		private IDialogService DialogService { get; set; } = default!;
		protected override async Task OnInitializedAsync()
		{
			await PopulateUserList();
			await PopulateCarList();
			await PopulateNoteList();
		}

		protected async Task ChangeUser()
		{
			await PopulateUserList();
			await PopulateCarList();
			await PopulateNoteList();
		}
		protected async Task PopulateCarList()
		{
			ListOfCars = await _service.GetCarByUserId(currentUser!.ID);
		}

		protected async Task SortCarsByYear()
		{
			ListOfCars = await _service.SortUsersCarsByYear(currentUser!.ID);
		}
		protected async Task AddCar()
		{
			newCar.UserId = currentUser.ID;
			await _service.AddCar(newCar);
			await PopulateCarList();
			newCar = new();
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
		//protected async Task UpdateCar(Car carToUpdate)
		//{
		//	var carList = await _service.GetAllCars();
		//	var actualCarToUpdate = carList.FirstOrDefault(c => c.Id == carToUpdate.Id);
		//	if (actualCarToUpdate != null)
		//	{
		//		await _service.UpdateCar(actualCarToUpdate);
		//		await PopulateCarList();
		//	}
		//}
		protected async Task PopulateUserList()
		{
			currentUser = await _userservice.GetUserById(initialUser);
		}

		
		protected async Task PopulateNoteList()
		{
				ListOfNotes = await _noteservice.GetNoteById(currentUser.ID);
		}
		//protected async Task AddNote()
		//{
		//	newNote.UserId = currentUser.ID;
		//	newNote.CarId = newCar.Id;
		//	await _noteservice.AddNote(newNote);
		//	await PopulateNoteList();
		//}

		
		protected void OpenDialog(List<Note> listOfNotes, Car car)
		{
			var parameters = new DialogParameters<CarNotes>();
			parameters.Add(p => p.Notes, listOfNotes);
			parameters.Add(p => p.Car, car);
			parameters.Add(p => p.User, currentUser);
			parameters.Add(p => p.OnClickEvent, EventCallback.Factory.Create(this, PopulateNoteList));
			var options = new DialogOptions { CloseOnEscapeKey = true };
			DialogService.Show<CarNotes>("Car Comments", parameters, options);
		}

		protected void OpenDialog(Car listOfCars)
		{
			var parameters = new DialogParameters<CarDetail>();
			parameters.Add(p => p.Car, listOfCars);
			var options = new DialogOptions { CloseOnEscapeKey = true };
			DialogService.Show<CarDetail>("Car Details", parameters, options);
		}
	}



}
