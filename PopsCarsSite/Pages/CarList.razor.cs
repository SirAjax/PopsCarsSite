﻿using EFTest.Models;
using Microsoft.AspNetCore.Components;
using PopsCars;

namespace PopsCarsSite.Pages
{
	public class CarListComponent : ComponentBase
	{
		protected List<Car> ListOfCars = new();
		protected string search;
		protected Car? newCar = new();
		protected Car? carToDelete = new();
		protected Car? carToUpdate = new();

		[Inject]
		private IService _service { get; set; } = default!;

		protected override async Task OnInitializedAsync()
		{
			await PopulateList();

		}
		protected async Task PopulateList()
		{
			ListOfCars = _service.GetAllCars();
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

		protected async Task AddCar()
		{
			{
				await _service.AddCar(newCar);
				await PopulateList();
			}
		}

		protected async Task UpdateCar(Car carToUpdate)
		{
			var carList = _service.GetAllCars().ToList();
			var actualCarToUpdate = carList.FirstOrDefault(c => c.Id == carToUpdate.Id);
			if (actualCarToUpdate != null)
			{
				await _service.UpdateCar(actualCarToUpdate);
				await PopulateList();
			}
		}
		protected async Task DeleteCar(Car carToDelete)
		{
			var carList = _service.GetAllCars().ToList();
			var actualCarToDelete = carList.FirstOrDefault(c => c.Id == carToDelete.Id);
			if (actualCarToDelete != null)
			{
				await _service.DeleteCar(actualCarToDelete);
				await PopulateList();
			}
		}
	}

}



