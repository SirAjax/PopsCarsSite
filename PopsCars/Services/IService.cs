using EFTest.Models;
using PopsCarsSite.Common.Models;

namespace PopsCars;
public interface IService
{
	Task <List<Car>> GetAllCars();

	Task<List<Car>> GetAllCarsByYear();
	Task<CommonResponse<List<Car>>> SortUsersCarsByYear(int userId);
	Task<List<Car>> MainSearch(string search);
	
	Task<List<Car>> GetCarByUserId(int id);
	Task<CommonResponse<bool>> AddCar(Car car);

	Task<bool> DeleteCar(Car car);
	Task<bool> UpdateCar(Car car);

	

}