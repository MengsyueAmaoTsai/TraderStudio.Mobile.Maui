using RichillCapital.TraderStudio.Mobile.Services.Navigation;

namespace RichillCapital.TraderStudio.Mobile.ViewModels;

public sealed partial class SignalSourcesViewModel : ViewModel
{
    public SignalSourcesViewModel(
        INavigationService navigationService)
        : base(navigationService)
    {
    }
}
