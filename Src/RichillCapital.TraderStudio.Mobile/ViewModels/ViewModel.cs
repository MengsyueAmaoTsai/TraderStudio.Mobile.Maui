using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using RichillCapital.TraderStudio.Mobile.Services.Dialog;
using RichillCapital.TraderStudio.Mobile.Services.Navigation;

namespace RichillCapital.TraderStudio.Mobile.ViewModels;

public abstract partial class ViewModel :
    ObservableObject,
    IViewModel
{
    private long _isBusy;
    protected readonly INavigationService _navigationService;
    protected readonly IDialogService _dialogService;

    protected ViewModel(
        INavigationService navigationService,
        IDialogService dialogService)
    {
        _navigationService = navigationService;
        _dialogService = dialogService;

        InitializeAsyncCommand =
            new AsyncRelayCommand(
                async () =>
                {
                    await IsBusyFor(InitializeAsync);
                },
                AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler);
    }

    public bool IsBusy => Interlocked.Read(ref _isBusy) > 0;
    public IAsyncRelayCommand InitializeAsyncCommand { get; }

    protected virtual Task InitializeAsync() => Task.CompletedTask;

    protected async Task IsBusyFor(Func<Task> unitOfWork)
    {
        Interlocked.Increment(ref _isBusy);
        OnPropertyChanged(nameof(IsBusy));

        try
        {
            await unitOfWork();
        }
        catch (Exception ex)
        {
            await _dialogService.ShowAlertAsync(
                "Error",
                $"An error occurred while processing your request. {ex.Message}",
                "Ok");
        }
        finally
        {
            Interlocked.Decrement(ref _isBusy);
            OnPropertyChanged(nameof(IsBusy));
        }
    }
}
