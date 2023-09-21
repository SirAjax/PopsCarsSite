using EFTest.Models;

namespace EFTest;
public interface ICarsRepository
{
	Task<List<Car>> GetCarsAsync();
}