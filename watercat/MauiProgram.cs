using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using watercat.Pages;
using watercat.ViewModel;

namespace watercat;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("Silkscreen-Regular.ttf", "Silkscreen");
                fonts.AddFont("PressStart2P-Regular.ttf", "PressStart2P");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainPageViewModel>();
        
        return builder.Build();
    }
}