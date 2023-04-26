using System;
using Microsoft.EntityFrameworkCore;
namespace crudWEBAPI.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}

		public DbSet<superHero> superHeroes { get; set; }

	}
}

