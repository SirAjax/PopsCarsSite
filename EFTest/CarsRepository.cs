﻿using Microsoft.EntityFrameworkCore;
using EFTest.GenericRepository;
using EFTest.Models;
using PopsCarsSite.Common.Models;


namespace EFTest
{
	public class CarsRepository : GenericRepository<Car>, ICarsRepository
	{
		public CarsRepository(PopsCarsContext popsCarsContext) : base(popsCarsContext)
		{
		}

		public async Task<GenericResponse<List<Car>>> GetAllCarsWithNotes(int userId)
		{
			var output = new GenericResponse<List<Car>>();
			try
			{
				output.Value = await _gdb.Set<Car>().Include(_gdb => _gdb.Notes).Where(n => n.UserId == userId).ToListAsync();
			}

			catch (Exception ex)
			{
				await output.SetExceptionAsync(ex);
			}
			return output;
		}
	}
	// Example of efcore using private variable naming convention
	//https://github.com/dotnet/efcore/blob/release/8.0/src/EFCore.SqlServer/SqlServerRetryingExecutionStrategy.cs
}

