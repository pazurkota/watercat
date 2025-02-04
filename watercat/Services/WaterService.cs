using watercat.Model;

namespace watercat.Services;

public class WaterService : IWaterService
{
    private const string WaterIntakeKey = "WaterIntake"; // key for storing water intake
    private const string LastUpdateDateKey = "LastUpdateDate"; // key for storing last update date
    private const string SetNewGoalKey = "DailyWaterGoal"; // key for storing user daily water goal

    private readonly IDailyIntakeDbService _intakeDbService = new DailyIntakeDbService();

    public int GetWaterIntake()
    {
        var lastUpdate = Preferences.Get(LastUpdateDateKey, DateTime.MinValue);
        if (lastUpdate.Date != DateTime.Today)
        {
            ResetWaterIntake();
        }
        return Preferences.Get(WaterIntakeKey, 0);
    }

    public async void AddWater(int amount)
    {
        int currentIntake = GetWaterIntake();
        currentIntake += amount;
        Preferences.Set(WaterIntakeKey, currentIntake);
        Preferences.Set(LastUpdateDateKey, DateTime.Today);

        await UpdateDailyIntake(currentIntake);
    }

    public async void ResetWaterIntake()
    {
        Preferences.Set(WaterIntakeKey, 0);
        Preferences.Set(LastUpdateDateKey, DateTime.Today);
        await UpdateDailyIntake(0);
    }

    public void SetDailyGoal(int newGoal)
    {
        Preferences.Set(SetNewGoalKey, newGoal);
    }

    public int GetDailyGoal()
    {
        return Preferences.Get(SetNewGoalKey, 2000);
    }

    private async Task UpdateDailyIntake(int amount)
    {
        var today = DateTime.Today;
        var intake = await _intakeDbService.GetByDate(today);
        if (intake == null)
        {
            intake = new DailyWaterIntake { Date = today, Intake = amount };
            await _intakeDbService.Create(intake);
        }
        else
        {
            intake.Intake = amount;
            await _intakeDbService.Update(intake);
        }
    }
}