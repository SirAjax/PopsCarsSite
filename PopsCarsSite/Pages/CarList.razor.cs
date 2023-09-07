using Microsoft.AspNetCore.Components;
using Pop_s_Cars;

namespace PopsCarsSite.Pages
{
    public class CarListComponent: ComponentBase
    {
        protected List<Cars> ListOfCars = new();
        protected int carYear;
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
            ListOfCars = await service.GetCarsByYear(carYear);
            StateHasChanged();
        }

        protected async Task FilterByModel()
        {
            ListOfCars = await service.GetCarsByModel(carModel);
        }

        protected async Task FilterByMake()
        {
            ListOfCars = await service.GetCarsByMake(carMake);
        }

        protected async Task FilterByColor()
        {
            ListOfCars = await service.GetCarsByColor(carColor);
        }
    }

}
