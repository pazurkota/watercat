using System.Collections.Generic;
using System.Threading.Tasks;
using watercat.Model;

public interface IDailyWaterIntakeRepository
{
	Task<IEnumerable<DailyWaterIntake>> GetAllAsync();
	Task<DailyWaterIntake> GetByIdAsync(int id);
	Task AddAsync(DailyWaterIntake dailyWaterIntake);
	Task UpdateAsync(DailyWaterIntake dailyWaterIntake);
	Task DeleteAsync(int id);
}