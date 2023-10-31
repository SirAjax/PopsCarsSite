using EFTest.Models;
using Microsoft.AspNetCore.Components;
using PopsCars;
using System.Diagnostics.Eventing.Reader;

namespace PopsCarsSite.Pages
{
	public class CarListComponent : ComponentBase
	{
		protected List<Car> ListOfCars = new();
		protected string search;
		protected EFTest.Models.Car? newCar = new();
		protected EFTest.Models.Car? carToDelete = new();

		[Inject]
		private IService _service { get; set; } = default!;

		protected override async Task OnInitializedAsync()
		{
			await PopulateList();
		}

		protected async Task PopulateList()
		{
			ListOfCars = await _service.GetAllCars();
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
	
		protected async Task AddCar()
		{
			{
				var result = await _service.AddCar(newCar);
				await PopulateList();
			}
		}

		protected async Task DeleteCar()
		{
			await _service.DeleteCar(carToDelete);
		}
		
	}
}


