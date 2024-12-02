using Microsoft.EntityFrameworkCore;
using watercat.Model;

namespace watercat.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
	public DbSet<DailyWaterIntake> DailyWaterIntakes { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<DailyWaterIntake>().Property(x => x.Id).ValueGeneratedOnAdd();
	}
}