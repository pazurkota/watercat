using CommunityToolkit.Maui.Views;

namespace watercat.Pages.Popups;

public partial class UnitChoosePopup : Popup
{
    public UnitChoosePopup()
    {
        InitializeComponent();
    }

    private void Button_SetMilliliters(object sender, EventArgs e)
    {
        Console.WriteLine("Set unit to milliliters!");
    }

    private void Button_SetOuncesUs(object sender, EventArgs e)
    {
        Console.WriteLine("Set unit to american ounces!");
    }
    
    private void Button_SetOuncesUk(object sender, EventArgs e)
    {
        Console.WriteLine("Set unit to british ounces!");
    }
}