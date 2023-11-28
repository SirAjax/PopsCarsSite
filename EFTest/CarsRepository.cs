using Microsoft.EntityFrameworkCore;
using EFTest.GenericRepository;
using EFTest.Models;


namespace EFTest
{
	public class CarsRepository :  GenericRepository<Car>, ICarsRepository
	{
		public CarsRepository(PopsCarsContext popsCarsContext): base(popsCarsContext) 
		{
		}
	}
	// Example of efcore using private variable naming convention
	//https://github.com/dotnet/efcore/blob/release/8.0/src/EFCore.SqlServer/SqlServerRetryingExecutionStrategy.cs
}

