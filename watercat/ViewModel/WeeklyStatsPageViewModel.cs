using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using watercat.Model;
using watercat.Services;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace watercat.ViewModel;

public partial class WeeklyStatsPageViewModel : ObservableObject
{
    private readonly IDailyIntakeDbService _intakeDbService = new DailyIntakeDbService();
    private readonly IUnitService _unitService = new UnitService();
    private readonly IWaterUnitConverter _waterUnitConverter = new WaterUnitConverter();
    private readonly SettingsPageViewModel _settingsViewModel;

    [ObservableProperty]
    private ObservableCollection<DailyWaterIntake> _weeklyIntakes;

    [ObservableProperty]
    private ISeries[] _series;

    [ObservableProperty]
    private Axis[] _xAxes;

    [ObservableProperty]
    private Axis[] _yAxes;

    public WeeklyStatsPageViewModel(SettingsPageViewModel settingsViewModel)
    {
        _settingsViewModel = settingsViewModel;
        _weeklyIntakes = new ObservableCollection<DailyWaterIntake>();
        LoadWeeklyStats();
    }

    public async void LoadWeeklyStats()
    {
        var intakes = await _intakeDbService.GetWeeklyIntakes();
        WeeklyIntakes.Clear();
        var seriesData = new List<double>();
        var dateLabels = new List<string>();

        foreach (var intake in intakes)
        {
            WeeklyIntakes.Add(intake);
            double intakeValue = intake.Intake;
            
            intakeValue = _waterUnitConverter.ConvertUnit(_unitService.GetUnit(), intakeValue);
            
            seriesData.Add(intakeValue);
            dateLabels.Add(intake.Date.ToString("MM/dd"));
        }

        Series = new ISeries[]
        {
            new ColumnSeries<double>
            {
                Values = seriesData,
                Fill = new SolidColorPaint(SKColors.Olive)
            }
        };

        XAxes = new Axis[]
        {
            new Axis
            {
                Labels = dateLabels,
                LabelsRotation = 45,
                TextSize = 12,
                Name = "Date",
                NameTextSize = 14,
                NamePaint = new SolidColorPaint(SKColors.Black)
            }
        };

        YAxes = new Axis[]
        {
            new Axis
            {
                MinLimit = 0
            }
        };
    }
}