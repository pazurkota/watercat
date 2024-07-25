using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace watercat.ViewModel;

public partial class WaterPopupPageViewModel : ObservableObject
{
    private readonly MainPageViewModel _mainPageViewModel;
    private readonly Action _closePopupAction;

    public WaterPopupPageViewModel(MainPageViewModel mainViewModel, Action closePopup)
    {
        _mainPageViewModel = mainViewModel;
        _closePopupAction = closePopup;
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