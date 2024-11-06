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
    }

    public ObservableCollection<BrokerageItem> Brokerages { get; } = [];

    protected override async Task InitializeAsync()
    {
        var result = await _brokerageService.ListBrokeragesAsync(default);

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
