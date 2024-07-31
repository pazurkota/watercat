using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using watercat.Pages.Popups;

namespace watercat.ViewModel;

public partial class MainPageViewModel : ObservableObject
{
    [ObservableProperty] private int _waterIntake;
    [ObservableProperty] private int _dailyWaterGoal;
    [ObservableProperty] private string _waterImage;
    [ObservableProperty] private string _waterSummary;
    [ObservableProperty] private string _appVersion;

    private const string WaterIntakeKey = "WaterIntake"; // key for storing water intake
    private const string LastUpdateDateKey = "LastUpdateDate"; // key for storing last update date

    public MainPageViewModel()
    {
        Initialize();
    }

    [RelayCommand]
    private void ShowPopUp()
    {
        Shell.Current.ShowPopup(new WaterPopupPage(this));
    }
    
    private void UpdateWaterSummary() => WaterSummary = $"{WaterIntake}ml/{DailyWaterGoal}ml";
    
    public void AddWater(string waterAmount)
    {
        WaterIntake += int.Parse(waterAmount);
        WaterImage = UpdateWaterImage();
        UpdateWaterSummary();
        
        // save current water stats
        Preferences.Set(WaterIntakeKey, WaterIntake);
        Preferences.Set(LastUpdateDateKey, DateTime.Today);
    }

    private void Initialize()
    {
        DailyWaterGoal = 2500;
        AppVersion = $"App version: v{VersionTracking.CurrentVersion}";
        
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
        WaterImage = UpdateWaterImage();
    }
    
    private string UpdateWaterImage()
    {
        var percentage = (double)WaterIntake / DailyWaterGoal;
        
        // 10% increment
        var index = (int)(percentage * 10);
        index = Math.Clamp(index, 0, 10);
        
        // return the image path
        return $"water_fill_{index * 10}.png";
    }
    
    [RelayCommand] // reset water stats
    private void ResetWaterIntake() 
    {
        WaterIntake = 0;
        UpdateWaterSummary();
        WaterImage = UpdateWaterImage();
    }
}