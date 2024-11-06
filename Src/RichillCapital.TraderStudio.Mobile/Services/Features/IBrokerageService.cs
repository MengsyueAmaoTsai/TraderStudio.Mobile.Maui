using RichillCapital.SharedKernel.Monads;
using RichillCapital.TraderStudio.Mobile.Models;

namespace RichillCapital.TraderStudio.Mobile.Services.Features;

public interface IBrokerageService
{
    Task<Result<IEnumerable<BrokerageItem>>> ListBrokeragesAsync(CancellationToken cancellationToken = default);
    Task<Result> DeleteBrokerageAsync(string name, CancellationToken cancellationToken = default);
}
