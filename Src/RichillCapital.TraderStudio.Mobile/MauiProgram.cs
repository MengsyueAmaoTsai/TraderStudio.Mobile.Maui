using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

using RichillCapital.TraderStudio.Mobile.Services.CurrentUser;
using RichillCapital.TraderStudio.Mobile.Services.Dialog;
using RichillCapital.TraderStudio.Mobile.Services.Features;
using RichillCapital.TraderStudio.Mobile.Services.Http;
using RichillCapital.TraderStudio.Mobile.Services.Navigation;
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

            // Register app services
            builder.Services.AddSingleton<ICurrentUser, CurrentUser>();
            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddSingleton<IDialogService, DialogService>();
            builder.Services.AddSingleton<IWebRequestHandler, WebRequestHandler>();

            builder.Services.AddSingleton<IBrokerageService, BrokerageService>();
            builder.Services.AddSingleton<IDataFeedService, DataFeedService>();
            builder.Services.AddSingleton<ISignalSourceService, SignalSourceService>();

            // Register views
            builder.Services.AddSingleton<MainPage>();

            builder.Services.AddSingleton<BrokeragesPage>();
            builder.Services.AddSingleton<DataFeedsPage>();
            builder.Services.AddSingleton<SignalSourcesPage>();

            // Register view models
            builder.Services.AddSingleton<MainViewModel>();

            builder.Services.AddSingleton<BrokeragesViewModel>();
            builder.Services.AddSingleton<DataFeedsViewModel>();
            builder.Services.AddSingleton<SignalSourcesViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
