using CommunityToolkit.Maui.Views;
using watercat.Pages.Popups;

namespace watercat.Pages;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
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