namespace RichillCapital.TraderStudio.Mobile.Views;

internal static class ViewExtensions
{
    internal static IServiceCollection AddViews(this IServiceCollection services)
    {
        services.AddSingleton<MainPage>();
     
        return services;
    }
}
