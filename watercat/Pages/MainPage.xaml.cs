using CommunityToolkit.Maui.Views;
using watercat.ViewModel;

namespace watercat.Pages;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}