using Microsoft.EntityFrameworkCore;
using EFTest.Models;
using EFTest.SeededData;
using Microsoft.Identity.Client;

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
			modelBuilder.ApplyConfiguration(new UserConfiguration());

			modelBuilder.Entity<User>().HasMany(u => u.Cars).WithOne(u => u.User).HasForeignKey(k => k.UserId);
		}

		//public var PopsCars = new Car []


    }
}