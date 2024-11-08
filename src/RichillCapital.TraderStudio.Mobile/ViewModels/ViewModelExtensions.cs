namespace RichillCapital.TraderStudio.Mobile.ViewModels;

internal static class ViewModelExtensions
{
    internal static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        services.AddSingleton<MainViewModel>();

        return services;
    }
}