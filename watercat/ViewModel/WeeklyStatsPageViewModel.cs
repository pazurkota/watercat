using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using watercat.Model;
using watercat.Services;

namespace watercat.ViewModel;

public partial class WeeklyStatsPageViewModel : ObservableObject
{
    private readonly IDailyIntakeDbService _intakeDbService = new DailyIntakeDbService();

    [ObservableProperty]
    private ObservableCollection<DailyWaterIntake> _weeklyIntakes;

    public WeeklyStatsPageViewModel()
    {
        _weeklyIntakes = new ObservableCollection<DailyWaterIntake>();
        LoadWeeklyStats();
    }

    public async void LoadWeeklyStats()
    {
        var intakes = await _intakeDbService.GetWeeklyIntakes();
        WeeklyIntakes.Clear();
        foreach (var intake in intakes)
        {
            WeeklyIntakes.Add(intake);
        }
    }
}