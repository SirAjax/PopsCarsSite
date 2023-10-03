using EFTest;
using EFTest.Models;

namespace PopsCars
{
	public class Service : IService
	{
		private readonly ICarsRepository _carsRepository;

		public Service(ICarsRepository carsRepository)
		{
			_carsRepository = carsRepository;
		}

		public async Task<List<Car>> GetAllCars()
		{
			return await _carsRepository.GetCarsAsync();
		}

		public async Task<List<Car>> MainSearch(string search)
		{
			List<Car> carList = await _carsRepository.GetCarsAsync();
			string[] searchOptions = search.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

			var searchResults = carList.Where(c =>
				searchOptions.All(term =>   //received help for line 19 
					c.Color!.Contains(term, StringComparison.InvariantCultureIgnoreCase) ||
					c.Make.Contains(term, StringComparison.InvariantCultureIgnoreCase) ||
					c.Model!.Contains(term, StringComparison.InvariantCultureIgnoreCase) ||
					c.Year.ToString().Contains(term))
			).ToList();

			return searchResults;
		}

		public void CreateNewUser(string userName)
		{
			User user = new User();
			user.UserName = userName;	
		}
	}
}
