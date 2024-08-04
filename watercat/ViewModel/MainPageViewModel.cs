using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using watercat.Models;
using watercat.Pages.Popups;
using watercat.Services;

namespace watercat.ViewModel;

public partial class MainPageViewModel : ObservableObject
{
    [ObservableProperty] private int _waterIntake;
    [ObservableProperty] private int _dailyWaterGoal = 2500;
    [ObservableProperty] private string _waterImage;
    [ObservableProperty] private string _waterSummary;
    [ObservableProperty] private string _appVersion;
    [ObservableProperty] private WaterUnit _selectedUnit;

    private readonly IWaterService _waterService;

    public MainPageViewModel()
    {
    }

    public MainPageViewModel(IWaterService waterService)
    {
        _waterService = waterService;
        Initialize();
    }

    [RelayCommand]
    private void ShowPopUp() => Shell.Current.ShowPopup(new WaterPopupPage(this));
    
    private void UpdateWaterSummary() => WaterSummary = $"{WaterIntake}{GetUnitSuffix(SelectedUnit)}/{DailyWaterGoal}{GetUnitSuffix(SelectedUnit)}";

    private void Initialize()
    {
        SelectedUnit = _waterService.GetUnit();
        WaterIntake = _waterService.GetWaterIntake();
        WaterImage = UpdateWaterImage();
        UpdateWaterSummary();
    }
    
    public void AddWater(string waterAmount)
    {
        int amount = ConvertFromSelectedUnit(int.Parse(waterAmount));
        _waterService.AddWater(amount);
        WaterIntake = amount;
        SelectedUnit = _waterService.GetUnit();
        WaterIntake = _waterService.GetWaterIntake();
        WaterImage = UpdateWaterImage();
        UpdateWaterSummary();
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
        _waterService.ResetWaterIntake();
        WaterImage = UpdateWaterImage();
    }
    
    private int ConvertFromSelectedUnit(int amount)
    {
        return SelectedUnit switch
        {
            WaterUnit.OuncesUs => (int)(amount * 29.5735),
            WaterUnit.OuncesUk => (int)(amount * 28.4131),
            _ => amount
        };
    }

    private string GetUnitSuffix(WaterUnit unit)
    {
        return unit switch
        {
            WaterUnit.Milliliters => "ml",
            WaterUnit.OuncesUs => "oz (US)",
            WaterUnit.OuncesUk => "oz (UK)",
            _ => "ml"
        };
    }
}