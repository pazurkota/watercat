using CommunityToolkit.Maui;
using LiveChartsCore.SkiaSharpView.Maui;
using Microsoft.Extensions.Logging;
using watercat.Pages;
using watercat.Services;
using watercat.ViewModel;
using SkiaSharp.Views.Maui.Controls.Hosting;
using watercat.Model;

namespace watercat;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseSkiaSharp()
            .UseLiveCharts()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("Silkscreen-Regular.ttf", "Silkscreen");
                fonts.AddFont("PressStart2P-Regular.ttf", "PressStart2P");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<DailyIntakeDbService>();
        
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainPageViewModel>();

        builder.Services.AddSingleton<SettingsPage>();
        builder.Services.AddSingleton<SettingsPageViewModel>();

        builder.Services.AddSingleton<WeeklyStatsPage>();
        builder.Services.AddSingleton<WeeklyStatsPageViewModel>();
        
        builder.Services.AddSingleton<IWaterService, WaterService>();
        builder.Services.AddSingleton<IUnitService, UnitService>();
        builder.Services.AddSingleton<IWaterUnitConverter, WaterUnitConverter>();
        builder.Services.AddSingleton<IDailyIntakeDbService, DailyIntakeDbService>();
        
        return builder.Build();
    }
}