using CommunityToolkit.Mvvm.Input;
using RichillCapital.TraderStudio.Mobile.Models;
using RichillCapital.TraderStudio.Mobile.Services.Dialog;
using RichillCapital.TraderStudio.Mobile.Services.Features;
using RichillCapital.TraderStudio.Mobile.Services.Navigation;
using System.Collections.ObjectModel;

namespace RichillCapital.TraderStudio.Mobile.ViewModels;

public sealed partial class BrokeragesViewModel : ViewModel
{
    private readonly IBrokerageService _brokerageService;

    public BrokeragesViewModel(
        INavigationService navigationService,
        IDialogService dialogService,
        IBrokerageService brokerageService)
        : base(navigationService, dialogService)
    {
        _brokerageService = brokerageService;
    }

    public ObservableCollection<BrokerageItem> Brokerages { get; } = [];

    protected override async Task InitializeAsync() => 
        await IsBusyFor(async () =>
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
        });

    [RelayCommand]
    private async Task ViewDetailsAsync(BrokerageItem item)
    {
        if (item is null)
        {
            await _dialogService.ShowAlertAsync("Error", "No item given", "Ok");
            return;
        }

        await _dialogService.ShowAlertAsync("Details", "This is brokerage details for ", "Ok");
    }
}
