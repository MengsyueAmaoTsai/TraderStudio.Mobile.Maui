using CommunityToolkit.Maui.Alerts;

namespace RichillCapital.TraderStudio.Mobile.Services;

internal sealed class SnackbarService : ISnackbarService
{
    public Task ShowAsync(
        string message, 
        CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }
}
