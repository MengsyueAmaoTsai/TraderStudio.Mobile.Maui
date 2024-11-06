using RichillCapital.SharedKernel.Monads;
using RichillCapital.TraderStudio.Mobile.Models;
using System.Net.Http.Json;

namespace RichillCapital.TraderStudio.Mobile.Services.Features;

internal class BrokerageService : IBrokerageService
{
    public BrokerageService()
    {
    }

    public Task<Result> DeleteBrokerageAsync(
        string name, 
        CancellationToken cancellationToken = default) => 
        throw new NotImplementedException();

    public async Task<Result<IEnumerable<BrokerageItem>>> ListBrokeragesAsync(CancellationToken cancellationToken = default)
    {
        List<BrokerageItem> brokerages = 
        [
            new()
            {
                Provider = "RichillCapital",
                Name = "RichillCapital.Exchange",
                Status = "Disconnected",
                Arguments = new()
                {
                    { "BaseAddress", "https://localhost:10000" },
                },
                CreatedTimeUtc = DateTimeOffset.UtcNow,
            },
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

        return Result<IEnumerable<BrokerageItem>>.With(brokerages!);
    }
}
