using RichillCapital.TraderStudio.Mobile.Services;

namespace RichillCapital.TraderStudio.Mobile.ViewModels;

public sealed partial class MainViewModel : ViewModel
{
    public MainViewModel(
        INavigationService navigationService)
        : base(navigationService)
    {
    }
}
