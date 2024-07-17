using CommunityToolkit.Maui.Views;

namespace watercat.Pages;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void Button_AddWater(object sender, EventArgs e)
    {
        this.ShowPopup(new WaterPopupPage());
    }
}