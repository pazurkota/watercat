using watercat.Model;

namespace watercat.Services;

public class WaterProgressTrackService(IWaterService waterService) : IWaterProgressTrackService
{
    public double GetProgressPercent()
    {
        if (waterService.GetDailyGoal() == 0) return 0;
        return (double)waterService.GetWaterIntake() / waterService.GetDailyGoal() * 100;
    }

    public double GetRemaining()
    {
        return Math.Max(waterService.GetDailyGoal() - waterService.GetWaterIntake(), 0);
    }
}

