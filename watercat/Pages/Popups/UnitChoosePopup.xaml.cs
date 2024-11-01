using CommunityToolkit.Maui.Views;
using watercat.Model;
using watercat.Services;

namespace watercat.Pages.Popups;

public partial class UnitChoosePopup : Popup
{
    private IUnitService _unitService;
    
    public UnitChoosePopup()
    {
        InitializeComponent();
        _unitService = new UnitService();
    }

    private void Button_SetMilliliters(object sender, EventArgs e)
    {
        _unitService.SetUnit(WaterUnits.Millilitres);
    }

    private void Button_SetOunces(object sender, EventArgs e)
    {
        _unitService.SetUnit(WaterUnits.Ounces);
    }
}