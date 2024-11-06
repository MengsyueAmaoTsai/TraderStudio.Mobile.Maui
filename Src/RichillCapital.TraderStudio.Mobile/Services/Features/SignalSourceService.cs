using RichillCapital.SharedKernel.Monads;
using RichillCapital.TraderStudio.Mobile.Models;
using RichillCapital.TraderStudio.Mobile.Services.Http;

namespace RichillCapital.TraderStudio.Mobile.Services.Features;

internal sealed class SignalSourceService(
    IWebRequestHandler _requestHandler) : 
    ISignalSourceService
{
    public async Task<Result<IEnumerable<SignalSourceItem>>> ListSignalSourcesAsync(
        CancellationToken cancellationToken = default)
    {
        var result = await _requestHandler.GetAsync<IEnumerable<SignalSourceItem>>("https://10.0.2.2:10000/api/v1/signal-sources");

        if (result.IsFailure)
        {
            return Result<IEnumerable<SignalSourceItem>>.Failure(result.Error);
        }

        return Result<IEnumerable<SignalSourceItem>>.With(result.Value);
    }
}
