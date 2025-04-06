namespace watercat.Model;

public interface IDailyIntakeDbService
{ 
    Task<List<DailyWaterIntake>> GetIntakes();
    Task<DailyWaterIntake> GetByDate(DateTime dateTime);
    Task Create(DailyWaterIntake intake);
    Task Update(DailyWaterIntake intake);
    Task Delete(DailyWaterIntake intake);
    Task<List<DailyWaterIntake>> GetWeeklyIntakes();
}