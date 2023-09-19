using Microsoft.EntityFrameworkCore;
using EFTest.Models;


namespace EFTest
{
	public class CarsRepository
	{
		private readonly PopsCarsContext _popsCarsContext;

		public CarsRepository(PopsCarsContext popsCarsContext)
		{
			_popsCarsContext = popsCarsContext;
		}

		public async Task<List<Cars>> GetCarsAsync()
		{
			return await _popsCarsContext.Cars.ToListAsync();
		}


	}

	
}

