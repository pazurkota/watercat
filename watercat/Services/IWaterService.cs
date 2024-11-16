namespace watercat.Services;

public interface IWaterService
{
    int GetWaterIntake();
    void AddWater(int amount);
    void ResetWaterIntake();
    void SetDailyGoal(int newGoal);
    int GetDailyGoal();
}