using EFTest.Models;
using EFTest.GenericRepository;
using PopsCarsSite.Common.Models;
namespace EFTest;
public interface ICarsRepository : IGenericRepository <Car>
{
    Task<CommonResponse<List<Car>>> GetAllCarsWithNotes(int userId);
}

