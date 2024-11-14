namespace watercat.Services;

public interface IWaterUnitConverter
{
    double ConvertToOz(double milliliters);
    double ConvertToMl(double ounces);
}