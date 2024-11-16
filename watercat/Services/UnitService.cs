using watercat.Model;

namespace watercat.Services;

public class UnitService : IUnitService
{
    private const string WaterUnitKey = "WaterUnit";
    
    public void SetUnit(WaterUnits unit)
    {
        Preferences.Set(WaterUnitKey, (int)unit);
    }

    public WaterUnits GetUnit()
    {
        return (WaterUnits)Preferences.Get(WaterUnitKey, 0);
    }

    public string UnitPrefix(WaterUnits unit)
    {
        return unit switch
        {
            WaterUnits.Millilitres => "ml",
            WaterUnits.Ounces => "oz",
            _ => "ml"
        };
    }
}