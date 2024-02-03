using EFTest.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudBlazor.Utilities;
using PopsCars;
using PopsCarsSite.Shared;
using System.Linq.Expressions;


namespace PopsCarsSite.Pages
{
	public class InitialUserComponent : ComponentBase
	{

		public InitialUserViewModel initialUserViewModel = new InitialUserViewModel();

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
			initialUserViewModel.ListOfCars = await _service.GetCarByUserId(initialUserViewModel.currentUser!.ID);
		}

		protected async Task SortCarsByYearOrId()
		{
			Expression<Func<Car, int>> expression = c => c.Id;
			initialUserViewModel.isSortedById = !initialUserViewModel.isSortedById;

			if (!initialUserViewModel.isSortedById)
			{
				expression = c => c.Year;
			}

			initialUserViewModel.ListOfCars = initialUserViewModel.ListOfCars.AsQueryable().OrderBy(expression).ToList();
		}
		protected async Task AddCar()
		{
			initialUserViewModel.newCar.UserId = initialUserViewModel.currentUser.ID;
			await _service.AddCar(initialUserViewModel.newCar);
			await PopulateCarList();
			initialUserViewModel.newCar = new();
		}
		protected async Task FilterBySearch()
		{
			if (string.IsNullOrEmpty(initialUserViewModel.search))
			{
				Console.WriteLine("no search results");
			}
			else
			{
				initialUserViewModel.ListOfCars = await _service.MainSearch(initialUserViewModel.search);
			}
		}

		protected async Task PopulateUserList()
		{
			initialUserViewModel.currentUser = await _userservice.GetUserById(initialUserViewModel.initialUser);
		}


		protected async Task PopulateNoteList()
		{
			initialUserViewModel.ListOfNotes = await _noteservice.GetNoteById(initialUserViewModel.currentUser.ID);
		}



		protected void OpenDialog(List<Note> listOfNotes, Car car)
		{
			var parameters = new DialogParameters<CarNotes>();
			parameters.Add(p => p.Notes, listOfNotes);
			parameters.Add(p => p.Car, car);
			parameters.Add(p => p.User, initialUserViewModel.currentUser);
			parameters.Add(p => p.OnClickEvent, EventCallback.Factory.Create(this, PopulateNoteList));
			var options = new DialogOptions { CloseOnEscapeKey = true };
			DialogService.Show<CarNotes>("Car Comments", parameters, options);
		}

		protected void OpenDialog(Car listOfCars)
		{
			var parameters = new DialogParameters<CarDetail>();
			parameters.Add(p => p.Car, listOfCars);
			parameters.Add(p => p.OnClickEvent, EventCallback.Factory.Create(this, PopulateNoteList));
			var options = new DialogOptions { CloseOnEscapeKey = true };
			DialogService.Show<CarDetail>("Car Details", parameters, options);
		}
	}
}
