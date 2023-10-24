using EFTest.Models;
using Microsoft.AspNetCore.Components;
using PopsCars;

namespace PopsCarsSite.Pages
{
	public class CarListComponent : ComponentBase
	{
		protected List<Car> ListOfCars = new();
		protected string search;
		protected EFTest.Models.Car? newCar = new();

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
			ListOfCars = await _service.MainSearch(search);
		}

		protected async Task AddCar()
		{
			{ 
				var result = await _service.AddCar(newCar);
				await PopulateList();
			}
		}
	}
}


