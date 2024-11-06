using RichillCapital.TraderStudio.Mobile.Models;
using RichillCapital.TraderStudio.Mobile.Services.Dialog;
using RichillCapital.TraderStudio.Mobile.Services.Features;
using RichillCapital.TraderStudio.Mobile.Services.Navigation;
using System.Collections.ObjectModel;

namespace RichillCapital.TraderStudio.Mobile.ViewModels;

public sealed partial class DataFeedsViewModel : ViewModel
{
    private readonly IDataFeedService _dataFeedService;

    public DataFeedsViewModel(
        INavigationService navigationService,
        IDialogService dialogService,
        IDataFeedService dataFeedService)
        : base(navigationService, dialogService)
    {
        _dataFeedService = dataFeedService;
    }

    public ObservableCollection<DataFeedItem> DataFeeds { get; } = [];

    protected override async Task InitializeAsync()
    {
        var result = await _dataFeedService.ListDataFeedsAsync(default);

        if (result.IsFailure)
        {
            return;
        }

        DataFeeds.Clear();

        foreach (var dataFeed in result.Value)
        {
            DataFeeds.Add(dataFeed);
        }
    }
}
