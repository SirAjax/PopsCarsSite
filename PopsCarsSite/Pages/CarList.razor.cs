using EFTest.Models;
using Microsoft.AspNetCore.Components;
using PopsCars;

namespace PopsCarsSite.Pages
{
	public class CarListComponent : ComponentBase
	{
		protected List<Car> ListOfCars = new();
		protected string search;

		[Inject]
		private IService _service { get; set; } = default!;

		protected override async Task OnInitializedAsync()
		{
			ListOfCars = await _service.GetAllCars();
		}

		protected async Task FilterBySearch()
		{
			ListOfCars = await _service.MainSearch(search);
		}



	}
}


