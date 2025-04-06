namespace watercat.Model;

public interface IWeeklyStatsService
{
    Task<IEnumerable<DailyWaterIntake>> GetDailyWaterIntakesAsync();
}