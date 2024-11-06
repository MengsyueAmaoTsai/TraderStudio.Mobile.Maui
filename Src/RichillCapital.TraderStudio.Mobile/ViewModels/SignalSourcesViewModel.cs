using RichillCapital.TraderStudio.Mobile.Models;
using RichillCapital.TraderStudio.Mobile.Services.Dialog;
using RichillCapital.TraderStudio.Mobile.Services.Features;
using RichillCapital.TraderStudio.Mobile.Services.Navigation;
using System.Collections.ObjectModel;

namespace RichillCapital.TraderStudio.Mobile.ViewModels;

public sealed partial class SignalSourcesViewModel : ViewModel
{
    private readonly ISignalSourceService _signalSourceService;

    public SignalSourcesViewModel(
        INavigationService navigationService,
        IDialogService dialogService,
        ISignalSourceService signalSourceService)
        : base(navigationService, dialogService)
    {
        _signalSourceService = signalSourceService;
    }

    public ObservableCollection<SignalSourceItem> SignalSources { get; } = [];

    protected override async Task InitializeAsync() =>
        await IsBusyFor(async () =>
        {
            var result = await _signalSourceService.ListSignalSourcesAsync(default);

            if (result.IsFailure)
            {
                return;
            }

            SignalSources.Clear();

            foreach (var signalSource in result.Value)
            {
                SignalSources.Add(signalSource);
            }
        });
}
