namespace RichillCapital.TraderStudio.Mobile.Services.Dialog;

public interface IDialogService
{
    Task ShowAlertAsync(string title, string message, string buttonLabel);
}