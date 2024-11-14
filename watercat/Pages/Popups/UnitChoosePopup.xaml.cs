using CommunityToolkit.Maui.Views;
using watercat.Model;
using watercat.Services;

namespace watercat.Pages.Popups;

public partial class UnitChoosePopup : Popup
{
    private readonly IUnitService _unitService = new UnitService();
    private readonly IWaterService _waterService = new WaterService();
    private readonly IWaterUnitConverter _unitConverter = new WaterUnitConverter();
    
    public UnitChoosePopup()
    {
        InitializeComponent();
    }

    private void Button_SetMilliliters(object sender, EventArgs e)
    {
        _unitService.SetUnit(WaterUnits.Millilitres);

        double dailyGoal = _waterService.GetDailyGoal();
        double convertedGoal = _unitConverter.ConvertToMl(dailyGoal);
        
        _waterService.SetDailyGoal((int) convertedGoal);
        
        Close();
    }

    private void Button_SetOunces(object sender, EventArgs e)
    {
        _unitService.SetUnit(WaterUnits.Ounces);
        
        double dailyGoal = _waterService.GetDailyGoal();
        double convertedGoal = _unitConverter.ConvertToOz(dailyGoal);
        
        _waterService.SetDailyGoal((int) convertedGoal);
        
        Close();
    }
}