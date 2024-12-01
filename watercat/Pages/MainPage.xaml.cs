using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using watercat.ViewModel;

namespace watercat.Pages;

public partial class MainPage : ContentPage
{
    private MainPageViewModel _viewModel;
    
    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.UpdateData();
    }
}