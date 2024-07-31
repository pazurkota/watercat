namespace watercat.Services;

public class WaterService : IWaterService
{
    private const string WaterIntakeKey = "WaterIntake"; // key for storing water intake
    private const string LastUpdateDateKey = "LastUpdateDate"; // key for storing last update date
    
    public int GetWaterIntake()
    {
        var lastUpdate = Preferences.Get(LastUpdateDateKey, DateTime.MinValue);
        if (lastUpdate.Date != DateTime.Today)
        {
            ResetWaterIntake();
        }
        return Preferences.Get(WaterIntakeKey, 0);
    }

    public void AddWater(int amount)
    {
        int currentIntake = GetWaterIntake();
        currentIntake += amount;
        Preferences.Set(WaterIntakeKey, currentIntake);
        Preferences.Set(LastUpdateDateKey, DateTime.Today);
    }

    public void ResetWaterIntake()
    {
        Preferences.Set(WaterIntakeKey, 0);
        Preferences.Set(LastUpdateDateKey, DateTime.Today);
    }
}