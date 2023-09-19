using Microsoft.AspNetCore.Components;
using PopsCars;
using EFTest.Models;
using EFTest;

namespace PopsCarsSite.Pages
{
	public class CarListComponent : ComponentBase
	{
		protected List<Cars> ListOfCars = new();
		protected string search;
		private Service service = new();
		[Inject]
		private CarsRepository _carsRepository { get; set; } = default!;
		protected override async Task OnInitializedAsync()
		{
			ListOfCars = await _carsRepository.GetCarsAsync();
		}
		

		protected async Task FilterBySearch()
		{
			ListOfCars = service.MainSearch(search);
		}

	}
}


