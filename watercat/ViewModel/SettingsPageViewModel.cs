using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using watercat.Pages.Popups;
using watercat.Services;

namespace watercat.ViewModel;

public partial class SettingsPageViewModel : ObservableObject
{
    private readonly IWaterService _waterService;
    
    public SettingsPageViewModel()
    {
    }

    public SettingsPageViewModel(IWaterService waterService)
    {
        _waterService = waterService;
    }
    
    [RelayCommand]
    private void ShowUnitsChoosePopup()
    {
        Shell.Current.ShowPopup(new UnitChoosePopup());
    }

    [RelayCommand]
    private void ShowAboutPopup()
    {
        Shell.Current.ShowPopup(new AboutPopupPage());
    }

    [RelayCommand]
    private void SetNewWaterGoal(int newGoal)
    {
        _waterService.SetDailyGoal(newGoal);
    }
}