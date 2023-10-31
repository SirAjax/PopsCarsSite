using EFTest.Models;

namespace EFTest;
public interface ICarsRepository
{
	Task<List<Car>> GetCarsAsync();

	Task<Car> AddCar(Car car);

	void DeleteCar(Car car);	
}