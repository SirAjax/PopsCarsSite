using EFTest.Models;

namespace PopsCars;
public interface IService
{
	Task<List<Car>> GetAllCars();
	Task<List<Car>> MainSearch(string search);

	Task<Car> AddCar(Car car);
}