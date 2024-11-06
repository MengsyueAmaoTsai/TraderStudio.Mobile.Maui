using CommunityToolkit.Mvvm.ComponentModel;
using RichillCapital.TraderStudio.Mobile.Services.Navigation;

namespace RichillCapital.TraderStudio.Mobile.ViewModels;

public abstract partial class ViewModel : 
    ObservableObject, 
    IViewModel
{
    private long _isBusy;
    protected readonly INavigationService _navigationService;

    protected ViewModel(
        INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    public bool IsBusy => Interlocked.Read(ref _isBusy) > 0;

    protected async Task IsBusyFor(Func<Task> unitOfWork)
    {
        Interlocked.Increment(ref _isBusy);
        OnPropertyChanged(nameof(IsBusy));

        try
        {
            await unitOfWork();
        }
        finally
        {
            Interlocked.Decrement(ref _isBusy);
            OnPropertyChanged(nameof(IsBusy));
        }
    }
}
