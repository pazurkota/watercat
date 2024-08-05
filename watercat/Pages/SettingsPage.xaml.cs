using CommunityToolkit.Maui.Views;
using watercat.Pages.Popups;
using watercat.ViewModel;

namespace watercat.Pages;

public partial class SettingsPage : ContentPage
{
    public SettingsPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = new SettingsPageViewModel(viewModel);
    }

    private void AboutButton_OnClicked(object sender, EventArgs e)
    {
        this.ShowPopup(new AboutPopupPage());
    }

    private void ChooseUnit_OnClicked(object sender, EventArgs e)
    {
        this.ShowPopup(new UnitChoosePopup());
    }
}