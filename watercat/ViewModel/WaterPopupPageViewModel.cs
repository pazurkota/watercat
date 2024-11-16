using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using watercat.Model;
using watercat.Services;

namespace watercat.ViewModel;

public partial class WaterPopupPageViewModel : ObservableObject
{
    [ObservableProperty] private string firstButton;
    [ObservableProperty] private string secondButton;
    [ObservableProperty] private string thirdButton;
    
    private readonly MainPageViewModel _mainPageViewModel;
    private readonly IUnitService _unitService = new UnitService();
    private readonly IWaterUnitConverter _unitConverter = new WaterUnitConverter();
    private readonly Action _closePopupAction;

    public WaterPopupPageViewModel(MainPageViewModel mainViewModel, Action closePopup)
    {
        _mainPageViewModel = mainViewModel;
        _closePopupAction = closePopup;

        WaterUnits unit = _unitService.GetUnit();

        FirstButton = $"{_unitConverter.ConvertUnit(unit, 180)} {_unitService.UnitPrefix(unit)}";
        SecondButton = $"{_unitConverter.ConvertUnit(unit, 250)} {_unitService.UnitPrefix(unit)}";
        ThirdButton = $"{_unitConverter.ConvertUnit(unit, 500)} {_unitService.UnitPrefix(unit)}";
    }

    public WaterPopupPageViewModel()
    {
    }

    [RelayCommand]
    private void AddWater(string amount)
    {
        _mainPageViewModel.AddWater(amount);
        _closePopupAction?.Invoke();
    }
}