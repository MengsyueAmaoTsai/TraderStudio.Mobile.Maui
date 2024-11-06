using RichillCapital.TraderStudio.Mobile.Services.Dialog;
using RichillCapital.TraderStudio.Mobile.Services.Navigation;

namespace RichillCapital.TraderStudio.Mobile.ViewModels;

public sealed partial class MainViewModel : ViewModel
{
    public MainViewModel(
        INavigationService navigationService,
        IDialogService dialogService)
        : base(navigationService, dialogService)
    {
    }
}
