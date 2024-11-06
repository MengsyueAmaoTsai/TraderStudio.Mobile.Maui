using RichillCapital.SharedKernel.Monads;
using RichillCapital.TraderStudio.Mobile.Models;

namespace RichillCapital.TraderStudio.Mobile.Services.Features;

internal sealed class SignalSourceService : ISignalSourceService
{
    public SignalSourceService()
    {
    }

    public async Task<Result<IEnumerable<SignalSourceItem>>> ListSignalSourcesAsync(
        CancellationToken cancellationToken = default)
    {
        List<SignalSourceItem> signalSources =
        [
            new()
            {
                Id = "TV-Long-Task",
                Name = "TradingView Long Task",
                Description = "TradingView Long Task",
                Visibility = "Public",
                CreatedTimeUtc = DateTimeOffset.UtcNow,
            },
            new()
            {
                Id = "TV-Short-Task",
                Name = "TradingView Short Task",
                Description = "TradingView Short Task",
                Visibility = "Public",
                CreatedTimeUtc = DateTimeOffset.UtcNow,
            },
        ];

        return Result<IEnumerable<SignalSourceItem>>.With(signalSources);
    }
}
