using watercat.Services;
using watercat.Model;

namespace watercat.Pages;

public partial class WeeklyStatsPage : ContentPage
{
    private readonly IDailyIntakeDbService _intakeDbService = new DailyIntakeDbService();
    
    public WeeklyStatsPage()
    {
        InitializeComponent();
        LoadWeeklyStats();
    }

    protected override void OnAppearing()
    {
        LoadWeeklyStats();
    }

    private async void LoadWeeklyStats()
    {
        var weeklyIntakes = await _intakeDbService.GetWeeklyIntakes();
        // Assuming you have a ListView or some UI element to display the data
        WeeklyStatsListView.ItemsSource = weeklyIntakes;
    }
}