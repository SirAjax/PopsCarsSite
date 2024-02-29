using EFTest;
using EFTest.Models;
using PopsCarsSite.Common.Models;
using AutoMapper;
using PopsCarsSite.Common;

namespace PopsCars
{
	public class CarService : ICarService
	{
		private readonly ICarsRepository _carsRepository;

		private readonly IMapper _mapper;

		public CarService(ICarsRepository carsRepository, IMapper mapper)
		{
			_carsRepository = carsRepository;
			_mapper = mapper;
		}

		public async Task<CommonResponse<List<Car>>> GetAllCars()
		{
			var retVal = new CommonResponse<List<Car>>();

			try
			{
				var carList = await _carsRepository.GetAll();
				//var carDTOList = _mapper.Map<List<CarDTO>>(carList);
				retVal.Value = carList.Value.ToList();
			}
			catch (Exception ex)
			{
				await retVal.SetExceptionAsync(ex);
			}
			return retVal;
		}


		public async Task<CommonResponse<List<Car>>> GetCarByUserId(int userId)
		{
			var usersCars = new CommonResponse<List<Car>>();

			try
			{
				CommonResponse<List<Car>> carList = await _carsRepository.GetAllCarsWithNotes(userId);
				usersCars.Value = carList.Value.Where(c => c.UserId == userId && c.Make != StringConstants.Example).ToList();
			}

			catch (Exception ex)
			{
				await usersCars.SetExceptionAsync(ex);
			}

			return usersCars;
		}

		public async Task<CommonResponse<List<Car>>> MainSearch(string search)
		{
			var retVal = new CommonResponse<List<Car>>();

			try
			{
				var carList = await _carsRepository.GetAll();

				string[] searchOptions = search.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				retVal.Value = carList.Value.Where(c =>
				searchOptions.All(term =>   
					c.Color!.Contains(term, StringComparison.InvariantCultureIgnoreCase) ||
					c.Make.Contains(term, StringComparison.InvariantCultureIgnoreCase) ||
					c.Model!.Contains(term, StringComparison.InvariantCultureIgnoreCase) ||
					c.Year.ToString().Contains(term))
					).ToList();
			}

			catch (Exception ex)
			{
				await retVal.SetExceptionAsync(ex);
			}

			return retVal;
		}

		public async Task<CommonResponse<Car>> AddCar(Car car)
		{
			var retVal = new CommonResponse<Car>();

			try
			{
				retVal = await _carsRepository.Add(car);
			}

			catch (Exception ex)
			{
				await retVal.SetExceptionAsync(ex);
			}

			return retVal;
		}

		public async Task<CommonResponse<bool>> DeleteCar(Car car)
		{
			var retVal = new CommonResponse<bool>();

			try
			{
				retVal = await _carsRepository.Delete(car);
			}

			catch (Exception ex)
			{ 
				await retVal.SetExceptionAsync(ex);
			}
			return retVal;
		}

		public async Task<CommonResponse<Car>> UpdateCar(Car car)
		{
			var retVal = new CommonResponse<Car>();
				
			try
			{
				retVal = await _carsRepository.UpdateAsync(car);
			}
			
			catch (Exception ex) 
			{
				await retVal.SetExceptionAsync(ex);
			}
			return retVal;
		}
	}
}
