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
    private readonly IWaterUnitConverter _unitConverter;

    public MainPageViewModel()
    {
    }

    public MainPageViewModel(IWaterService waterService, IUnitService unitService, IWaterUnitConverter unitConverter)
    {
        _waterService = waterService;
        _unitService = unitService;
        _unitConverter = unitConverter;
        
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
        var percentage = ConvertUnit(WaterIntake) / DailyWaterGoal;
        
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

    public void UpdateData()
    {
        WaterIntake = _waterService.GetWaterIntake();
        DailyWaterGoal = _waterService.GetDailyGoal(); // depend on selected unit
        WaterImage = UpdateWaterImage();

        string waterIntake = $"{_unitConverter.ConvertUnit(_unitService.GetUnit(), WaterIntake)}";
        
        WaterSummary = $"{waterIntake}/{DailyWaterGoal}";
    }

    private double ConvertUnit(double value)
    {
        WaterUnits unit = _unitService.GetUnit();

        return unit switch
        {
            WaterUnits.Ounces => _unitConverter.ConvertToOz(value),
            _ => value
        };
    }
}