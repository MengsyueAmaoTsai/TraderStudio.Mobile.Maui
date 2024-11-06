using RichillCapital.SharedKernel.Monads;
using RichillCapital.TraderStudio.Mobile.Models;

namespace RichillCapital.TraderStudio.Mobile.Services.Features;

public interface IDataFeedService
{
    Task<Result<IEnumerable<DataFeedItem>>> ListDataFeedsAsync(CancellationToken cancellationToken = default);
}