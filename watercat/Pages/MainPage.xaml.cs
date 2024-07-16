namespace watercat.Pages;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void Button_AddWater(object sender, EventArgs e)
    {
        await DisplayPromptAsync("Add water", "Enter water amount below (in ml):", keyboard: Keyboard.Numeric);
    }
}