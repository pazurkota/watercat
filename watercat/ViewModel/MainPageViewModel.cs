using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using watercat.Model;
using watercat.Pages.Popups;
using watercat.Services;

namespace watercat.ViewModel;

public partial class MainPageViewModel : ObservableObject
{
    [ObservableProperty] private int _waterIntake;
    [ObservableProperty] private int _dailyWaterGoal = 2500;
    [ObservableProperty] private string _waterImage;
    [ObservableProperty] private string _waterSummary;
    [ObservableProperty] private string _waterUnit;
    [ObservableProperty] private string _appVersion;

    private readonly IWaterService _waterService;
    private readonly IUnitService _unitService;

    public MainPageViewModel()
    {
    }

    public MainPageViewModel(IWaterService waterService, IUnitService unitService)
    {
        _waterService = waterService;
        _unitService = unitService;
        Initialize();
    }

    [RelayCommand]
    private void ShowPopUp() => Shell.Current.ShowPopup(new WaterPopupPage(this));
    
    public void AddWater(string waterAmount)
    {
        _waterService.AddWater(int.Parse(waterAmount));
        UpdateData();
    }

    private void Initialize()
    {
        UpdateData();
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
        _waterService.ResetWaterIntake();
        UpdateData();
    }

    private void UpdateData()
    {
        WaterIntake = _waterService.GetWaterIntake();
        WaterImage = UpdateWaterImage();

        string waterIntake = $"{ConvertWaterByUnit.ConvertUnits(_unitService.GetUnit(), $"{WaterIntake}")}";
        string dailyGoal = $"{ConvertWaterByUnit.ConvertUnits(_unitService.GetUnit(), $"{DailyWaterGoal}")}";
        
        WaterSummary = $"{waterIntake}/{dailyGoal}";
    }
}