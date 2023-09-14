using Microsoft.AspNetCore.Components;
using PopsCars;

namespace PopsCarsSite.Pages
{
	public class CarListComponent : ComponentBase
	{
		protected List<Cars> ListOfCars = new();
		protected string search;
		private Service service = new();
		protected override async Task OnInitializedAsync()
		{
			ListOfCars = service.GetAllCars();
		}
		

		protected async Task FilterBySearch()
		{
			ListOfCars = service.MainSearch(search);
		}
	}
}


