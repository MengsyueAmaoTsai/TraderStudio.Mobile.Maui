using CommunityToolkit.Mvvm.Input;
using RichillCapital.TraderStudio.Mobile.Models;
using RichillCapital.TraderStudio.Mobile.Services.Features;
using RichillCapital.TraderStudio.Mobile.Services.Navigation;
using System.Collections.ObjectModel;

namespace RichillCapital.TraderStudio.Mobile.ViewModels;

public sealed partial class BrokeragesViewModel : ViewModel
{
    private readonly IBrokerageService _brokerageService;

    public BrokeragesViewModel(
        INavigationService navigationService,
        IBrokerageService brokerageService)
        : base(navigationService)
    {
        _brokerageService = brokerageService;

        ListBrokeragesAsyncCommand =
            new AsyncRelayCommand(
                async () =>
                {
                    await IsBusyFor(ListBrokeragesAsync);
                },
                AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler);
    }

    public IAsyncRelayCommand ListBrokeragesAsyncCommand { get; }
    public ObservableCollection<BrokerageItem> Brokerages { get; } = [];

    private async Task ListBrokeragesAsync()
    {
        var result = await _brokerageService.ListBrokeragesAsync();

        if (result.IsFailure)
        {
            return;
        }

        Brokerages.Clear();

        foreach (var b in result.Value)
        {
            Brokerages.Add(b);
        }
    }
}
