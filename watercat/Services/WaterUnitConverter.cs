﻿namespace watercat.Services;

public class WaterUnitConverter : IWaterUnitConverter
{
    public double ConvertToOz(double milliliters)
    {
        return Math.Round(milliliters * 0.033814, 1);
    }

    public double ConvertToMl(double ounces)
    {
        return Math.Round(ounces * 29.5735, 0);
    }
}