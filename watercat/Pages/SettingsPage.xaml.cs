using CommunityToolkit.Maui.Views;

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
}