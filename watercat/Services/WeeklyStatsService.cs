using watercat.Model;

namespace watercat.Services;

public class WeeklyStatsService(IDailyIntakeDbService dailyIntakeDbService) : IWeeklyStatsService
{
    public async Task<IEnumerable<DailyWaterIntake>> GetDailyWaterIntakesAsync()
    {
        return await dailyIntakeDbService.GetWeeklyIntakes();
    }
}