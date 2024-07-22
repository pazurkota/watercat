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
}