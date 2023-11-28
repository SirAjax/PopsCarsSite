﻿using EFTest.Models;

namespace PopsCars;
public interface IService
{
	List<Car> GetAllCars();
	Task<List<Car>> MainSearch(string search);

	Task<bool> AddCar(Car car);

	Task DeleteCar(Car car);
}