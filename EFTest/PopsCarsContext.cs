using Microsoft.EntityFrameworkCore;
using EFTest.Models;


namespace EFTest
{
	public class PopsCarsContext: DbContext
	{	
		public PopsCarsContext (DbContextOptions<PopsCarsContext> options) : base(options)
		{

		}

		public DbSet<Cars> Cars { get; set; } 
		public DbSet<Users> Users { get; set; }	
		public DbSet<Notes> Notes { get; set; }



	}
}