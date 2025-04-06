namespace watercat.Model;

public interface IUnitService
{
    void SetUnit(WaterUnits unit);
    WaterUnits GetUnit();
    string UnitPrefix(WaterUnits unit);
}