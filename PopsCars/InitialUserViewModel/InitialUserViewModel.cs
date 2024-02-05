using EFTest.Models;

namespace PopsCars
{
	public class InitialUserViewModel
	{
		
		public List<Car> ListOfCars = new();
		public List<Note> ListOfNotes = new();
		public Car newCar = new();
		public Car carToUpdate = new();
		public Car carToDelete = new();
		public int initialUser { get; set; } = 1;
		public User currentUser = new();
		public Note newNote = new();
		public Note noteToUpdate = new();
		public Note noteToDelete = new();
		public string search;
		public bool isSortedById = true;
		public string sortButtonText;
	}
}


