using Microsoft.Extensions.Logging;
using RazorClassLibrary.ViewModels; // Add your namespace

namespace Deuda
{
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
                });

            builder.Services.AddMauiBlazorWebView();

            // Registering as Transient creates a new instance every time a component is loaded
            builder.Services.AddTransient<UserViewModel>();

#if WINDOWS
    // Use the bool overload only for Windows if needed
    // Otherwise, sticking to the parameterless CreateBuilder() is safer cross-platform
    builder = MauiApp.CreateBuilder(true); 
#endif

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
