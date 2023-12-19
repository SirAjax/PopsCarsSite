using EFTest.Models;

namespace PopsCars;
public interface IService
{
	Task <List<Car>> GetAllCars();
	Task<List<Car>> MainSearch(string search);

	Task<bool> AddCar(Car car);

	Task<bool> DeleteCar(Car car);
	Task<bool> UpdateCar(Car car);
}