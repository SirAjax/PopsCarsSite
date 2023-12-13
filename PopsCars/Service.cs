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

		public List<Car> GetAllCars()
		{
			return _carsRepository.GetAll().ToList();
		}

		public async Task<List<Car>> MainSearch(string search)
		{
			List<Car> carList =  _carsRepository.GetAll().ToList();
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

        public async Task<bool> AddCar(Car car)
        {
            return _carsRepository.Add(car);
        }

		public async Task<bool> DeleteCar(Car car)
		{
			return _carsRepository.Delete(car);
		}

		public Task<bool> UpdateCar(Car car)
		{
            return _carsRepository.UpdateAsync(car);
        }

	}
}
