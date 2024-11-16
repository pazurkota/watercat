using watercat.Model;

namespace watercat.Services;

public interface IWaterUnitConverter
{
    double ConvertToOz(double milliliters);
    double ConvertToMl(double ounces);
    double ConvertUnit(WaterUnits unit, double value);
}