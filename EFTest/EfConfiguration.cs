using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EFTest
{
	public static class EfConfiguration
	{
		public static void ConfigRepositoryContext(this IServiceCollection services, string defaultConnection)
		{
			services.AddDbContext<PopsCarsContext>(options => options.UseSqlServer(defaultConnection));
		}
	}
}
