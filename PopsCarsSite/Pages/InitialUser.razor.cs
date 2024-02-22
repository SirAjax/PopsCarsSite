using EFTest.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using PopsCars;
using PopsCarsSite.Common.Models;
using PopsCarsSite.Shared;
using System.Linq.Expressions;


namespace PopsCarsSite.Pages
{
	public class InitialUserComponent : ComponentBase
	{
		public InitialUserViewModel initialUserViewModel = new InitialUserViewModel();

		[Inject]
		private ISnackbar _snackBar { get; set; } = default!;

		[Inject]
		private ICarService _service { get; set; } = default!;

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
			try
			{
				var carList = new CommonResponse<List<Car>>();
				carList = await _service.GetCarByUserId(initialUserViewModel.currentUser!.ID);
				if (carList.Error)
				{
					_snackBar.Add("Error in retrieving car list", Severity.Error);
				}
				else
				{
					initialUserViewModel.ListOfCars = carList.Value;
				}
			}
			catch (Exception ex)
			{
				_snackBar.Add("Error in retrieving car list", Severity.Error);
			}
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
			try
			{
				initialUserViewModel.newCar.UserId = initialUserViewModel.currentUser.ID;
				CommonResponse<Car> addCarResponse = await _service.AddCar(initialUserViewModel.newCar);
				if (addCarResponse.Error || addCarResponse.Value is null)
				{
					_snackBar.Add("Please enter a value for each slot", Severity.Error);
				}
				else
				{
					await PopulateCarList();
					initialUserViewModel.newCar = new();
				}
			}
			catch (Exception ex)
			{
				_snackBar.Add("Unable to Add Car", Severity.Error);
			}
		}
		protected async Task FilterBySearch()
		{
			if (string.IsNullOrEmpty(initialUserViewModel.search))
			{
				Console.WriteLine("no search results");
			}
			else
			{
				try
				{
					var carList = new CommonResponse<List<Car>>();
					carList = await _service.MainSearch(initialUserViewModel.search);
					if (carList.Error)
					{
						_snackBar.Add("could not find any cars by that search", Severity.Error);
					}
					else
					{
						initialUserViewModel.ListOfCars = carList.Value;
					}
				}
				catch (Exception ex)
				{
					_snackBar.Add("could not find any cars by that search", Severity.Error);
				}
			}
		}

		protected async Task PopulateUserList()
		{
			try
			{
				var initialUser = new CommonResponse<User>();
				initialUser = await _userservice.GetUserById(initialUserViewModel.initialUser);
				if (initialUser.Error)
				{
					_snackBar.Add("Error in retrieving user list", Severity.Error);
				}
				else
				{
					initialUserViewModel.currentUser = initialUser.Value;
				}
			}

			catch (Exception ex)
			{
				_snackBar.Add("Error in retrieving car list", Severity.Error);
			}
			
		}
		protected async Task PopulateNoteList()
		{
			try
			{
				var noteList = new CommonResponse<List<Note>>();
				noteList = await _noteservice.GetNoteById(initialUserViewModel.currentUser.ID);
				if (noteList.Error)
				{
					_snackBar.Add("Error in retrieving note list", Severity.Error);
				}
				else
				{
					initialUserViewModel.ListOfNotes = noteList.Value;
				}
			}
			catch (Exception ex)
			{
				_snackBar.Add("Error in retrieving note list", Severity.Error);
			}
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
