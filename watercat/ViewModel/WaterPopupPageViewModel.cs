using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using watercat.Services;

namespace watercat.ViewModel;

public partial class WaterPopupPageViewModel : ObservableObject
{
    private readonly MainPageViewModel _mainPageViewModel;
    private readonly Action _closePopupAction;
    
    [ObservableProperty] private string firstButton;
    [ObservableProperty] private string secondButton;
    [ObservableProperty] private string thirdButton;

    public WaterPopupPageViewModel(MainPageViewModel mainViewModel, Action closePopup)
    {
        _mainPageViewModel = mainViewModel;
        _closePopupAction = closePopup;
        
        var unitService = new UnitService();
        
        FirstButton = ConvertWaterByUnit.ConvertButtonUnits(unitService.GetUnit(), "180");
        SecondButton = ConvertWaterByUnit.ConvertButtonUnits(unitService.GetUnit(), "250");
        ThirdButton = ConvertWaterByUnit.ConvertButtonUnits(unitService.GetUnit(), "500");
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