using watercat.Models;

namespace watercat.Services;

public interface IWaterService
{
    int GetWaterIntake();
    void AddWater(int amount);
    void ResetWaterIntake();
    WaterUnit GetUnit();
    void SetUnit(WaterUnit unit);
}