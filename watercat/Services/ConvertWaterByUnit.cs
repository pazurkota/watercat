using watercat.Model;

namespace watercat.Services;

public static class ConvertWaterByUnit
{
    public static string ConvertUnits(WaterUnits unit, int value)
    {
        return unit switch
        {
            WaterUnits.Millilitres => $"{value} ml",
            WaterUnits.Ounces => $"{Math.Round(value * 0.033814, 1) } oz",
            _ => $"{value} ml"
        };
    }
}