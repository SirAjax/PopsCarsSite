﻿using EFTest;
using EFTest.Models;
using PopsCarsSite.Common.Models;

namespace PopsCars
{
	public class Service : IService
	{
		private readonly ICarsRepository _carsRepository;

		public Service(ICarsRepository carsRepository)
		{
			_carsRepository = carsRepository;
		}

		public async Task<CommonResponse<List<Car>>> GetAllCars()
		{
			var listOfAllCars = new CommonResponse<List<Car>>();

			try
			{
				CommonResponse<List<Car>> carList = _carsRepository.GetAll().ToList();
				listOfAllCars.Value = carList.Value;
			}
			catch (Exception ex)
			{
				await listOfAllCars.SetExceptionAsync(ex);
			}
			return listOfAllCars;
		}

		public async Task<CommonResponse<List<Car>>> GetAllCarsByYear()
		{
			var listOfAllCarsByYear = new CommonResponse<List<Car>>();

			try
			{
				listOfAllCarsByYear.Value = _carsRepository.GetAll().OrderBy(x => x.Year).ToList();
			}

			catch (Exception ex)
			{
				await listOfAllCarsByYear.SetExceptionAsync(ex);
			}

			return listOfAllCarsByYear;
		}

		public async Task<CommonResponse<List<Car>>> SortUsersCarsByYear(int userId)

		{
			var usersCarsSorted = new CommonResponse<List<Car>>();

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


		public async Task<CommonResponse<List<Car>>> GetCarByUserId(int userId)
		{
			var usersCars = new CommonResponse<List<Car>>();

			try
			{
				CommonResponse<List<Car>> carList = await _carsRepository.GetAllCarsWithNotes(userId);
				usersCars.Value = carList.Value.Where(c => c.UserId == userId).ToList();
			}

			catch (Exception ex)
			{
				await usersCars.SetExceptionAsync(ex);
			}

			return usersCars;
		}

		public async Task<CommonResponse<List<Car>>> MainSearch(string search)
		{
			var searchResults = new CommonResponse<List<Car>>();

			try
			{
				var carList = _carsRepository.GetAll().ToList();
				string[] searchOptions = search.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				searchResults.Value = carList.Where(c =>
				searchOptions.All(term =>   //received help for line 19 
					c.Color!.Contains(term, StringComparison.InvariantCultureIgnoreCase) ||
					c.Make.Contains(term, StringComparison.InvariantCultureIgnoreCase) ||
					c.Model!.Contains(term, StringComparison.InvariantCultureIgnoreCase) ||
					c.Year.ToString().Contains(term))
					).ToList();
			}

			catch (Exception ex)
			{
				await searchResults.SetExceptionAsync(ex);
			}
			
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

		public async Task<CommonResponse<bool>> DeleteCar(Car car)
		{
			var retVal = new CommonResponse<bool>();

			try
			{
				retVal.Value = await _carsRepository.Delete(car);

			}

			catch (Exception ex)
			{ 
				await retVal.SetExceptionAsync(ex);
			}
			return retVal;
		}

		public async Task<CommonResponse<bool>> UpdateCar(Car car)
		{
			var retVal = new CommonResponse<bool>();

			try
			{
				retVal.Value = await _carsRepository.UpdateAsync(car);
			}
			
			catch (Exception ex) 
			{
				await retVal.SetExceptionAsync(ex);
			}
			return retVal;
		}
	}
}
