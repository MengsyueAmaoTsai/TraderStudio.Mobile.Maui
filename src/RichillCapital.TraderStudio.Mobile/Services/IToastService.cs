namespace RichillCapital.TraderStudio.Mobile.Services;

public interface IToastService
{
    Task ShowAsync(string message, CancellationToken cancellationToken = default);
}
