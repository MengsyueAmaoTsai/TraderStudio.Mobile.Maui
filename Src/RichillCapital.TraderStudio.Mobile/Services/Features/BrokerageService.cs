using RichillCapital.SharedKernel.Monads;
using RichillCapital.TraderStudio.Mobile.Models;
using RichillCapital.TraderStudio.Mobile.Services.Http;

namespace RichillCapital.TraderStudio.Mobile.Services.Features;

internal sealed class BrokerageService(
    IWebRequestHandler _requestHandler) : 
    IBrokerageService
{
    public Task<Result> DeleteBrokerageAsync(
        string name, 
        CancellationToken cancellationToken = default) => 
        throw new NotImplementedException();

    public async Task<Result<IEnumerable<BrokerageItem>>> ListBrokeragesAsync(CancellationToken cancellationToken = default)
    {
        var result = await _requestHandler.GetAsync<IEnumerable<BrokerageItem>>("https://10.0.2.2:10000/api/v1/brokerages");

        if (result.IsFailure)
        {
            return Result<IEnumerable<BrokerageItem>>.Failure(result.Error);
        }

        return Result<IEnumerable<BrokerageItem>>.With(result.Value);
    }
}
