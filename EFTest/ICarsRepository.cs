using EFTest.Models;
using EFTest.GenericRepository;
namespace EFTest;
public interface ICarsRepository : IGenericRepository <Car>
{
    Task<List<Car>> GetAllCarsWithNotes(int userId);
}

