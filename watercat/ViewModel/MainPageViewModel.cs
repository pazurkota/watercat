﻿using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using watercat.Pages;

namespace watercat.ViewModel;

public partial class MainPageViewModel : ObservableObject
{
    [ObservableProperty] private int _waterIntake;
    [ObservableProperty] private int _dailyWaterGoal;
    [ObservableProperty] private string _waterImage;
    [ObservableProperty] private string _waterSummary;

    private const string WaterIntakeKey = "WaterIntake"; // key for storing water intake
    private const string LastUpdateDateKey = "LastUpdateDate"; // key for storing last update date

    public MainPageViewModel()
    {
        Initialize();
        DailyWaterGoal = 2500;
        WaterImage = CalculateWaterImage();
    }

    [RelayCommand]
    private void ShowPopUp()
    {
        Shell.Current.ShowPopup(new WaterPopupPage(this));
    }
    
    public void AddWater(string waterAmount)
    {
        WaterIntake += int.Parse(waterAmount);
        WaterImage = CalculateWaterImage();
        UpdateWaterSummary();
        
        // save current water stats
        Preferences.Set(WaterIntakeKey, WaterIntake);
        Preferences.Set(LastUpdateDateKey, DateTime.Today);
    }

    private void Initialize()
    {
        var lastUpdate = Preferences.Get(LastUpdateDateKey, DateTime.MinValue);

        // reset if new day
        if (lastUpdate.Date != DateTime.Today) 
        {
            WaterIntake = 0;
            Preferences.Set(WaterIntakeKey, 0);
            Preferences.Set(LastUpdateDateKey, DateTime.Today);
        }
        else
        {
            WaterIntake = Preferences.Get(WaterIntakeKey, 0);
        }
        
        UpdateWaterSummary();
    }
    
    private string CalculateWaterImage()
    {
        var percentage = (double)WaterIntake / DailyWaterGoal;
        
        // 10% increment
        var index = (int)(percentage * 10);
        index = Math.Clamp(index, 0, 10);
        
        // return the image path
        return $"water_fill_{index * 10}.png";
    }

    private void UpdateWaterSummary() => WaterSummary = $"{WaterIntake}ml/{DailyWaterGoal}ml";
}