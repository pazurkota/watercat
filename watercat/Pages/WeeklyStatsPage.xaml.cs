using watercat.ViewModel;

namespace watercat.Pages;

public partial class WeeklyStatsPage : ContentPage
{
    private readonly WeeklyStatsPageViewModel _viewModel;
    
    public WeeklyStatsPage(WeeklyStatsPageViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        _viewModel.LoadWeeklyStats();
    }
}