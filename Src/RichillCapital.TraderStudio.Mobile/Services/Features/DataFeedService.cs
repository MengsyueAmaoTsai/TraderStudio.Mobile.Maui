using RichillCapital.SharedKernel.Monads;
using RichillCapital.TraderStudio.Mobile.Models;
using RichillCapital.TraderStudio.Mobile.Services.Http;

namespace RichillCapital.TraderStudio.Mobile.Services.Features;

internal sealed class DataFeedService(
    IWebRequestHandler _requestHandler) : 
    IDataFeedService
{
    public async Task<Result<IEnumerable<DataFeedItem>>> ListDataFeedsAsync(CancellationToken cancellationToken = default)
    {
        var result = await _requestHandler.GetAsync<IEnumerable<DataFeedItem>>("https://10.0.2.2:10000/api/v1/data-feeds");
        if (result.IsFailure)
        {
            return Result<IEnumerable<DataFeedItem>>.Failure(result.Error);
        }

        return Result<IEnumerable<DataFeedItem>>.With(result.Value);
    }
}