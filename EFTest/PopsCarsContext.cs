using EFTest.Models;
using EFTest.SeededData;
using Microsoft.EntityFrameworkCore;

namespace EFTest
{
    public class PopsCarsContext: DbContext
	{
		public virtual DbSet<Car> Car { get; set; }
		public virtual DbSet<User> User { get; set; }
		public virtual DbSet<Note> Note { get; set; }

		public PopsCarsContext (DbContextOptions<PopsCarsContext> options) : base(options)
		{

		}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
			optionsBuilder.
				LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Name }, Microsoft.Extensions.Logging.LogLevel.Information).EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new CarConfiguration());
			modelBuilder.ApplyConfiguration(new UserConfiguration());
			modelBuilder.ApplyConfiguration(new NoteConfiguration());
		}
    }
}