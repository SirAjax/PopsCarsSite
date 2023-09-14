using Microsoft.AspNetCore.Components;
using PopsCars;

namespace PopsCarsSite.Pages
{
	public class CarListComponent : ComponentBase
	{
		protected List<Cars> ListOfCars = new();
		protected int? carYear;
		protected string carModel;
		protected string carMake;
		protected string carColor;
		private Service service = new();
		protected override async Task OnInitializedAsync()
		{
			ListOfCars = service.GetAllCars();
		}
		protected async Task FilterByYear()
		{
			if (carYear.HasValue)
			{
				ListOfCars = service.GetCarsByYear(carYear.Value);
			}
			else
			{
				ListOfCars = new();
			}
		}

		protected async Task FilterByModel()
		{
			ListOfCars = service.GetCarsByModel(carModel);
		}

		protected async Task FilterByMake()
		{
			ListOfCars = service.GetCarsByMake(carMake);
		}

		protected async Task FilterByColor()
		{
			ListOfCars = service.GetCarsByColor(carColor);
		}
	}

}
