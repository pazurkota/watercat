using watercat.Model;

namespace watercat.Services;

public interface IUnitService
{
    void SetUnit(WaterUnits unit);
    WaterUnits GetUnit();
    string UnitPrefix(WaterUnits unit);
}