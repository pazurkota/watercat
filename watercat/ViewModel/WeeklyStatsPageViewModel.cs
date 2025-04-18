﻿using CommunityToolkit.Mvvm.ComponentModel;
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
    private readonly IUnitService _unitService = new UnitService();
    private readonly IWaterUnitConverter _waterUnitConverter = new WaterUnitConverter();
    private readonly IWeeklyStatsService _weeklyStatsService;

    [ObservableProperty]
    private ObservableCollection<DailyWaterIntake> _weeklyIntakes = new();

    [ObservableProperty]
    private ISeries[] _series;

    [ObservableProperty]
    private Axis[] _xAxes;

    [ObservableProperty]
    private Axis[] _yAxes;

    public WeeklyStatsPageViewModel(IWeeklyStatsService service)
    {
        _weeklyStatsService = service;
        LoadWeeklyStats();
    }

    public async void LoadWeeklyStats()
    {
        var intakes = await _weeklyStatsService.GetDailyWaterIntakesAsync();
        WeeklyIntakes.Clear();
        
        var seriesData = new List<double>();
        var dateLabels = new List<string>();

        foreach (var intake in intakes)
        {
            WeeklyIntakes.Add(intake);
            double intakeValue = intake.Intake;
            
            intakeValue = _waterUnitConverter.ConvertUnit(_unitService.GetUnit(), intakeValue);
            
            seriesData.Add(intakeValue);
            dateLabels.Add(intake.Date.ToString("MM/dd/yyyy"));
        }

        Series =
        [
            new ColumnSeries<double>
            {
                Values = seriesData,
                Fill = new SolidColorPaint(SKColor.Parse("#A3D5FF"))
            }
        ];

        XAxes =
        [
            new Axis
            {
                Labels = dateLabels,
                LabelsRotation = 45,
                TextSize = 12,
                NameTextSize = 14,
                LabelsPaint = new SolidColorPaint(SKColor.Parse("#A3D5FF"))
            }
        ];

        YAxes =
        [
            new Axis
            {
                MinLimit = 0,
                LabelsPaint = new SolidColorPaint(SKColor.Parse("#A3D5FF"))
            }
        ];
    }
}