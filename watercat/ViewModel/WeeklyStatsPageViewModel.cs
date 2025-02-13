using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using watercat.Model;
using watercat.Services;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace watercat.ViewModel;

public partial class WeeklyStatsPageViewModel : ObservableObject
{
    private readonly IDailyIntakeDbService _intakeDbService = new DailyIntakeDbService();

    [ObservableProperty]
    private ObservableCollection<DailyWaterIntake> _weeklyIntakes;

    [ObservableProperty]
    private ISeries[] _series;

    public WeeklyStatsPageViewModel()
    {
        _weeklyIntakes = new ObservableCollection<DailyWaterIntake>();
        LoadWeeklyStats();
    }

    public async void LoadWeeklyStats()
    {
        var intakes = await _intakeDbService.GetWeeklyIntakes();
        WeeklyIntakes.Clear();
        var seriesData = new List<double>();

        foreach (var intake in intakes)
        {
            WeeklyIntakes.Add(intake);
            seriesData.Add(intake.Intake);
        }

        Series =
        [
            new ColumnSeries<double>(seriesData)
        ];
    }
}