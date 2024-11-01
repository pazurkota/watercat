using watercat.Model;

namespace watercat.Services;

public static class ConvertWaterByUnit
{
    public static string ConvertUnits(WaterUnits unit, string value)
    {
        return unit switch
        {
            WaterUnits.Millilitres => $"{value} ml",
            WaterUnits.Ounces => $"{Math.Round(int.Parse(value) / 28.4, 0) } oz",
            _ => $"{value} ml"
        };
    }
}