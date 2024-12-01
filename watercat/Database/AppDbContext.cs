using Microsoft.EntityFrameworkCore;
using watercat.Model;

namespace watercat.Database;

public class AppDbContext : DbContext
{
	public DbSet<DailyWaterIntake> DailyWaterIntakes { get; set; }
	
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<DailyWaterIntake>().HasKey(x => x.Id);
	}
}