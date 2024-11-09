using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using RichillCapital.TraderStudio.Mobile.Services;
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

            builder.Services.AddSingleton<ICurrentUser, CurrentUser>();
            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddSingleton<IDialogService, DialogService>();
            builder.Services.AddSingleton<IToastService, ToastService>();

            builder.Services.AddViewModels();
            builder.Services.AddViews();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
