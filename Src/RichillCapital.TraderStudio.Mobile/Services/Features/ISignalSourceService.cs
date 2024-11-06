using RichillCapital.SharedKernel.Monads;
using RichillCapital.TraderStudio.Mobile.Models;

namespace RichillCapital.TraderStudio.Mobile.Services.Features;

public interface ISignalSourceService
{
    Task<Result<IEnumerable<SignalSourceItem>>> ListSignalSourcesAsync(CancellationToken cancellationToken = default);
}