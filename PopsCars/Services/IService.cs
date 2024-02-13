using EFTest.Models;
using PopsCarsSite.Common.Models;

namespace PopsCars;
public interface IService
{
	Task<CommonResponse<List<Car>>> GetAllCars();
	Task<CommonResponse<List<Car>>> MainSearch(string search);
	Task<CommonResponse<List<Car>>> GetCarByUserId(int id);
	Task<CommonResponse<bool>> AddCar(Car car);
	Task<CommonResponse<bool>> DeleteCar(Car car);
	Task<CommonResponse<bool>> UpdateCar(Car car);
}