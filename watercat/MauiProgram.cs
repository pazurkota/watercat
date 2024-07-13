using Microsoft.Extensions.Logging;

namespace watercat;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("DMSans-Regular.ttf", "DMSans-Regular");
                fonts.AddFont("PressStart2P-Regular.ttf", "PressStart2P-Regular");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}