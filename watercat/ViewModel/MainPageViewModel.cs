using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using watercat.Pages;

namespace watercat.ViewModel;

public partial class MainPageViewModel : ObservableObject
{
    [ObservableProperty] private int _waterIntake;
    [ObservableProperty] private int _dailyWaterGoal;
    [ObservableProperty] private double _waterHeight;
    [ObservableProperty] private string _waterSummary;

    public MainPageViewModel()
    {
        WaterIntake = 0;
        DailyWaterGoal = 2500;
        WaterHeight = 0;
        WaterSummary = $"0ml/{DailyWaterGoal}ml";
    }

    [RelayCommand]
    private void ShowPopUp()
    {
        Shell.Current.ShowPopup(new WaterPopupPage(this));
    }
    
    public void AddWater(string waterAmount)
    {
        WaterIntake += int.Parse(waterAmount);
        WaterSummary = $"{WaterIntake}ml/{DailyWaterGoal}ml";
    }
}