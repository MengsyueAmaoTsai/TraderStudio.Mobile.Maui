namespace RichillCapital.TraderStudio.Mobile.Services;

public interface ISnackbarService
{
    Task ShowAsync(string message, CancellationToken cancellationToken = default);
}