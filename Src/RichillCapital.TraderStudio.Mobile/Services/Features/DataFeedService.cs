using RichillCapital.SharedKernel.Monads;
using RichillCapital.TraderStudio.Mobile.Models;

namespace RichillCapital.TraderStudio.Mobile.Services.Features;

internal sealed class DataFeedService : IDataFeedService
{
    public async Task<Result<IEnumerable<DataFeedItem>>> ListDataFeedsAsync(CancellationToken cancellationToken = default)
    {
        List<DataFeedItem> dataFeeds =
        [
            new()
            {
                Provider = "Max",
                Name = "RichillCapital.Max",
                Status = "Disconnected",
                Arguments = new()
                {
                },
                CreatedTimeUtc = DateTimeOffset.UtcNow,
            },
            new()
            {
                Provider = "Binance",
                Name = "RichillCapital.Binance",
                Status = "Disconnected",
                Arguments = new()
                {
                },
                CreatedTimeUtc = DateTimeOffset.UtcNow,
            },
        ];

        return Result<IEnumerable<DataFeedItem>>.With(dataFeeds);
    }
}