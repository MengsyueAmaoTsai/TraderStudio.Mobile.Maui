using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace RichillCapital.TraderStudio.Mobile.Services;

internal sealed class ToastService : IToastService
{
    public Task ShowAsync(
        string message,
        CancellationToken cancellationToken = default)
    {
        Toast
            .Make(message, ToastDuration.Long, 30)
            .Show(cancellationToken);

        return Task.CompletedTask;
    }
}
