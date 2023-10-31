﻿using Microsoft.EntityFrameworkCore;
using EFTest.Models;
using EFTest.SeededData;
using Microsoft.Identity.Client;
using Microsoft.Extensions.Logging;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
			optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PubDatabase").
				LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Name}, Microsoft.Extensions.Logging.LogLevel.Information).EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new CarConfiguration());
			modelBuilder.ApplyConfiguration(new UserConfiguration());

			//modelBuilder.Entity<User>().HasMany(u => u.Cars).WithOne(u => u.User);
		}

		


    }
}