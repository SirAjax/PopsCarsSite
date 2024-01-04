using EFTest.Models;
using Microsoft.AspNetCore.Components;
using PopsCars;


namespace PopsCarsSite.Pages
{
	public class InitialUserComponent : ComponentBase
	{

        protected List<Car> ListOfCars = new();
		protected List<Note> ListOfNotes = new();
		protected Car? newCar = new();
        protected Car? carToUpdate = new();
		protected Car? carToDelete = new();
        protected User? currentUser = new();
        protected Note? newNote = new();
		protected string search;
		
		[Inject]
		private IService _service { get; set; } = default!;

        [Inject]
        private IUserService _userservice { get; set; } = default!;

        [Inject]

        private INoteService _noteservice { get; set; } = default!;

        protected override async Task OnInitializedAsync()
		{
			await PopulateCarList();
			await PopulateUserList();
			await PopulateNoteList();
		}
		protected async Task PopulateCarList()
		{
			ListOfCars = await _service.GetAllCars();
		}
		
		protected async Task AddCar()
		{
            newCar.UserId = currentUser.ID;

			await _service.AddCar(newCar);
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
        protected async Task UpdateCar(Car carToUpdate)
        {
            var carList = await _service.GetAllCars();
            var actualCarToUpdate = carList.FirstOrDefault(c => c.Id == carToUpdate.Id);
            if (actualCarToUpdate != null)
            {
                await _service.UpdateCar(actualCarToUpdate);
                await PopulateCarList();
            }
        }

      
        protected async Task DeleteCar(Car carToDelete)
        {
            var carList = await _service.GetAllCars();
            var actualCarToDelete = carList.FirstOrDefault(c => c.Id == carToDelete.Id);

            if (actualCarToDelete != null)
            {
                await _service.DeleteCar(actualCarToDelete);
                await PopulateCarList();
            }
        }

        protected async Task PopulateUserList()
		{
            currentUser = await _userservice.GetUserById(1);
		}

	
		protected async Task PopulateNoteList()
		{
			ListOfNotes = await _noteservice.GetNotes();
		}
           protected async Task AddNote()
        {
            await _noteservice.AddNote(newNote);
            await PopulateNoteList();
        }
    }
}
