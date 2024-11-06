using RichillCapital.TraderStudio.Mobile.Models;
using RichillCapital.TraderStudio.Mobile.Services.Navigation;
using System.Collections.ObjectModel;

namespace RichillCapital.TraderStudio.Mobile.ViewModels;

public sealed partial class DataFeedsViewModel : ViewModel
{
    public DataFeedsViewModel(INavigationService navigationService)
        : base(navigationService)
    {
    }

    public ObservableCollection<DataFeedItem> DataFeeds { get; } = [];
}
