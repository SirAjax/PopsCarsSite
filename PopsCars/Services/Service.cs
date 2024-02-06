using EFTest;
using EFTest.Models;
using PopsCarsSite.Common.Models;
using System.Diagnostics;

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
			return _carsRepository.GetAll().ToList();
		}

		public async Task<List<Car>> GetAllCarsByYear()
		{
			return _carsRepository.GetAll().OrderBy(x => x.Year).ToList();
		}
		
		public async Task<CommonResponse<List<Car>>> SortUsersCarsByYear(int userId)

		{
			var usersCarsSorted  = new CommonResponse<List<Car>>();

			try
			{
				CommonResponse<List<Car>> carList = await _carsRepository.GetAllCarsWithNotes(userId);
				usersCarsSorted.Value = carList.Value.Where(c => c.UserId == userId).OrderBy(c => c.Year).ToList();
			}
			catch (Exception ex)
			{
				await usersCarsSorted.SetExceptionAsync(ex);
			}
				return usersCarsSorted;

		}

		
		public async Task<List<Car>> GetCarByUserId(int userId)
		{
			CommonResponse<List<Car>> carList = await _carsRepository.GetAllCarsWithNotes(userId);
			var usersCars = carList.Value.Where(c => c.UserId == userId).ToList();
			return usersCars;
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

        public async Task<CommonResponse<bool>> AddCar(Car car)
        {
			var retVal = new CommonResponse<bool>();

			try
			{
				retVal.Value = await _carsRepository.Add(car);
			}
			
			catch (Exception ex) 
			
			{
				await retVal.SetExceptionAsync(ex);
			}

			return retVal;

        }

		public async Task<bool> DeleteCar(Car car)
		{
			return await _carsRepository.Delete(car);
		}

		public async Task<bool> UpdateCar(Car car)
		{
			return await _carsRepository.UpdateAsync(car);
		}
	}
}
