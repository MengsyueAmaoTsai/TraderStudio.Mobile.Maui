using RichillCapital.TraderStudio.Mobile.Services;

namespace RichillCapital.TraderStudio.Mobile.ViewModels;

public sealed partial class MainViewModel : ViewModel
{
    public MainViewModel(
        ICurrentUser currentUser,
        INavigationService navigationService)
        : base(currentUser, navigationService)
    {
    }
}
