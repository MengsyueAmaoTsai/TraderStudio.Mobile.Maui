using RichillCapital.TraderStudio.Mobile.Models;
using RichillCapital.TraderStudio.Mobile.Services.Navigation;
using System.Collections.ObjectModel;

namespace RichillCapital.TraderStudio.Mobile.ViewModels;

public sealed partial class SignalSourcesViewModel : ViewModel
{
    public SignalSourcesViewModel(
        INavigationService navigationService)
        : base(navigationService)
    {
    }

    public ObservableCollection<SignalSourceItem> SignalSources { get; } = [];
}
