using EFTest.Models;
using PopsCarsSite.Common.Models;

namespace PopsCars;
public interface ICarService
{
	Task<CommonResponse<List<Car>>> GetAllCars();
	Task<CommonResponse<List<Car>>> MainSearch(string search);
	Task<CommonResponse<List<Car>>> GetCarByUserId(int id);
	Task<CommonResponse<Car>> AddCar(Car car);
	Task<CommonResponse<bool>> DeleteCar(Car car);
	Task<CommonResponse<Car>> UpdateCar(Car car);
}