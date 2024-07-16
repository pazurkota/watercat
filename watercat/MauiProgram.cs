﻿using Microsoft.Extensions.Logging;

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
                fonts.AddFont("Silkscreen-Regular.ttf", "Silkscreen");
                fonts.AddFont("PressStart2P-Regular.ttf", "PressStart2P");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}