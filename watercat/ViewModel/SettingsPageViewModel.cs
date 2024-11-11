using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using watercat.Pages.Popups;

namespace watercat.ViewModel;

public partial class SettingsPageViewModel : ObservableObject
{
    public SettingsPageViewModel()
    {
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
}