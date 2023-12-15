using EFTest.Models;

namespace PopsCars;
public interface IService
{
	Task <List<Car>> GetAllCars();
	Task<List<Car>> MainSearch(string search);

	Task AddCar(Car car);

	Task DeleteCar(Car car);
	Task UpdateCar(Car car);
}