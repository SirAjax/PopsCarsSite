using Microsoft.EntityFrameworkCore;
using EFTest.Models;


namespace EFTest
{
	public class CarsRepository : ICarsRepository
	{
		private readonly PopsCarsContext _popsCarsContext;

		public CarsRepository(PopsCarsContext popsCarsContext)
		{
			_popsCarsContext = popsCarsContext;
		}

		public async Task<List<Car>> GetCarsAsync()
		{
			return await _popsCarsContext.Car.ToListAsync();
		}
	}

	// Example of efcore using private variable naming convention
	//https://github.com/dotnet/efcore/blob/release/8.0/src/EFCore.SqlServer/SqlServerRetryingExecutionStrategy.cs
}

