using Microsoft.EntityFrameworkCore;
using EFTest.Models;
using EFTest.SeededData;

namespace EFTest
{
	public class PopsCarsContext: DbContext
	{
		public DbSet<Car> Car { get; set; }
		public DbSet<User> User { get; set; }
		public DbSet<Note> Note { get; set; }

		public PopsCarsContext (DbContextOptions<PopsCarsContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new CarConfiguration());
		}
	}
}