using RichillCapital.TraderStudio.Mobile.Pages;

namespace RichillCapital.TraderStudio.Mobile;

public sealed partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        RegisterRoutes();
    }

    private static void RegisterRoutes()
    {
        Routing.RegisterRoute(nameof(SignalSourcesPage), typeof(SignalSourcesPage));
    }
}
