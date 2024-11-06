using CommunityToolkit.Mvvm.Input;

namespace RichillCapital.TraderStudio.Mobile.ViewModels;

public interface IViewModel
{
    bool IsBusy { get; }
    IAsyncRelayCommand InitializeAsyncCommand { get; }
}
