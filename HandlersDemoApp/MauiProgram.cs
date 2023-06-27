using Microsoft.Extensions.Logging;
using TestMauiHandlers;
using TestMauiHandlers.Handlers;

namespace HandlersDemoApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
            //.ConfigureMauiHandlers((handlers) =>
            //{
            //    handlers.AddHandler(typeof(CustomEntry), typeof(CustomEntryHandler));

            //});

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}

