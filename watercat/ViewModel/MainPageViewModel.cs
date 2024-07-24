using CommunityToolkit.Maui.Views;
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

    public MainPageViewModel()
    {
        WaterIntake = 0;
        DailyWaterGoal = 2500;
        WaterImage = CalculateWaterImage();
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
        WaterImage = CalculateWaterImage();
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
}