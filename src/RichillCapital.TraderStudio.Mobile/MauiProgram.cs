using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using RichillCapital.TraderStudio.Mobile.ViewModels;
using RichillCapital.TraderStudio.Mobile.Views;

namespace RichillCapital.TraderStudio.Mobile
{
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
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<MainPage>();

            builder.Services.AddSingleton<MainViewModel>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
