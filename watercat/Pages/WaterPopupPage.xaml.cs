using CommunityToolkit.Maui.Views;
using watercat.ViewModel;

namespace watercat.Pages;

public partial class WaterPopupPage : Popup
{
    public WaterPopupPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void AddWater_OnPressed(object sender, EventArgs e)
    {
        var viewModel = (MainPageViewModel)BindingContext;
        
        viewModel.AddWater(180);
        Close();
    }
}