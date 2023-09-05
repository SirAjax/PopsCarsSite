using Microsoft.AspNetCore.Components;
using Pop_s_Cars;

namespace PopsCarsSite.Pages
{
    public class CarListComponent: ComponentBase
    {
        protected List<Cars> ListOfCars = new();
        protected int carYear;
        private Service service = new();
        protected override async Task OnInitializedAsync()
        {
            ListOfCars = service.GetAllCars();
        }
        protected async Task FilterByYear()
        {
            ListOfCars = service.GetCarsByYear(carYear);
            StateHasChanged();
        }
    }

}
