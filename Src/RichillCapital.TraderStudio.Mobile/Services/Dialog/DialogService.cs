namespace RichillCapital.TraderStudio.Mobile.Services.Dialog;

internal sealed class DialogService : IDialogService
{
    public Task ShowAlertAsync(
        string title,
        string message,
        string buttonLabel)
    {
        if (Application.Current is null || 
            Application.Current.MainPage is null)
        {
            throw new InvalidOperationException("Application.Current.MainPage is null");
        }

        return Application.Current.MainPage.DisplayAlert(title, message, buttonLabel); 
    }
}
